using AttendanceApi.Repository.Data.Contexts;
using AttendanceApi.Repository.Identity.contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AttendanceDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDbContext<AttendanceIdentity>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});


var app = builder.Build();



// Configure the HTTP request pipeline.
var scoped = app.Services.CreateScope();
var service = scoped.ServiceProvider;
var context = service.GetRequiredService<AttendanceDbContext>();
var contextIdentity = service.GetRequiredService<AttendanceIdentity>();
var loggerFactory = service.GetRequiredService<ILoggerFactory>();
try
{
    await context.Database.MigrateAsync();
    await AttendanceSeedDbContext.SeedData(context);
    await contextIdentity.Database.MigrateAsync();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
