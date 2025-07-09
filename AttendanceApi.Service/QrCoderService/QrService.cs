using AttendanceApi.Core;
using AttendanceApi.Core.Service.Contract.QrServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;


namespace AttendanceApi.Service.QrCoderService
{
    public class QrService : IQrService
    {
        public Task<string> CreateQrCodeAsync(int lectureId)
        {
            var payload = new QrPayload
            {
                LectureId = lectureId,
                ExpireAt = DateTime.UtcNow.AddMinutes(3)
            };

            var qrJson = JsonSerializer.Serialize(payload);

            var writer = new BarcodeWriter<Bitmap>
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 300,
                    Width = 300,
                    Margin = 1
                },
                Renderer = new BitmapRenderer()
            };

            using var bitmap = writer.Write(qrJson);
            using var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            var bytes = ms.ToArray();
            var base64Image = Convert.ToBase64String(bytes);

            return Task.FromResult($"data:image/png;base64,{base64Image}");
        }

    }
}

