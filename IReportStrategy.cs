using System.Collections.Generic;

namespace IoTDeviceMonitor
{
    public interface IReportStrategy
    {
        string GenerateReport(List<Device> devices);
    }
}
