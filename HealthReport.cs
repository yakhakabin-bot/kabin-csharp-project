using System.Collections.Generic;
using System.Text;

namespace IoTDeviceMonitor
{
    public class HealthReport : IReportStrategy
    {
        public string GenerateReport(List<Device> devices)
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("Device Health Report");
            report.AppendLine("====================");
            report.AppendLine($"Total Devices: {devices.Count}");
            report.AppendLine();

            int healthyCount = 0;

            foreach (var device in devices)
            {
                if (device.Status == DeviceStatus.Online)
                {
                    healthyCount++;
                    report.AppendLine($"✓ {device.Name} ({device.DeviceID}): Healthy - {device.Status}");
                }
                else
                {
                    report.AppendLine($"✗ {device.Name} ({device.DeviceID}): Issue - {device.Status}");
                }
            }

            report.AppendLine();
            report.AppendLine($"Health Status: {healthyCount}/{devices.Count} devices online ({(devices.Count > 0 ? (healthyCount * 100 / devices.Count) : 0)}%)");

            return report.ToString();
        }
    }
}
