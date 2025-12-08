using System.Collections.Generic;
using System.Text;

namespace IoTDeviceMonitor
{
    public class StatusReport : IReportStrategy
    {
        public string GenerateReport(List<Device> devices)
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("Device Status Report");
            report.AppendLine("====================");

            int onlineCount = 0, offlineCount = 0, maintenanceCount = 0;

            foreach (var device in devices)
            {
                switch (device.Status)
                {
                    case DeviceStatus.Online:
                        onlineCount++;
                        break;
                    case DeviceStatus.Offline:
                        offlineCount++;
                        break;
                    case DeviceStatus.Maintenance:
                        maintenanceCount++;
                        break;
                }
            }

            report.AppendLine($"Online: {onlineCount}");
            report.AppendLine($"Offline: {offlineCount}");
            report.AppendLine($"Maintenance: {maintenanceCount}");
            report.AppendLine($"Total Devices: {devices.Count}");

            return report.ToString();
        }
    }
}
