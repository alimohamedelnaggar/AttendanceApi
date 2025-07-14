using AttendanceApi.Core;
using AttendanceApi.Core.Entities.Identity;
using AttendanceApi.Core.Mapper;
using AttendanceApi.Core.Service.Contract;
using AttendanceApi.Repository;
using AttendanceApi.Repository.Data.Contexts;
using AttendanceApi.Repository.Identity;
using AttendanceApi.Repository.Identity.contexts;
using AttendanceApi.Service;
using AttendanceApi.Service.Qr;
using AttendanceApi.Service.Token;
using AttendanceApi.Service.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(m => m.AddProfile(new StudentProfile()));

builder.Services.AddDbContext<AttendanceDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDbContext<AttendanceIdentity>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});

builder.Services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<AttendanceIdentity>();

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.AddScoped<IInstructorService,InstructorService>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IQrService,QrService>();


builder.Services.AddAuthentication(op =>
{
    op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(op =>
{
    op.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});


var app = builder.Build();


// Configure the HTTP request pipeline.
var scoped = app.Services.CreateScope();
var service = scoped.ServiceProvider;
var context = service.GetRequiredService<AttendanceDbContext>();
var contextIdentity = service.GetRequiredService<AttendanceIdentity>();
var userManager=service.GetRequiredService<UserManager<AppUser>>();
var loggerFactory = service.GetRequiredService<ILoggerFactory>();
try
{
    await context.Database.MigrateAsync();
    await AttendanceSeedDbContext.SeedData(context);
    await contextIdentity.Database.MigrateAsync();
    await IdentitySeed.SeedIdentityAsync(userManager);
     await SeedRole.AddRoleAsync(service);

}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex.Message);
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
