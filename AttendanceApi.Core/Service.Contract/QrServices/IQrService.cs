using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Core.Service.Contract.QrServices
{
    public interface IQrService
    {
        public Task<string> CreateQrCodeAsync(int lectureId);
    }
}
