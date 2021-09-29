using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.ProjectEaton.Common.Services
{
    public interface IDeviceMessageService
    {
        Task<List<DeviceMessage>> Get();
        Task<DeviceMessage> Create(DeviceMessage dm);
    }
}
