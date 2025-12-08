using System;

namespace IoTDeviceMonitor
{
    public class TemperatureSensor : Device
    {
        public TemperatureSensor(string deviceID, string name, string ipAddress, DeviceStatus status = DeviceStatus.Offline)
            : base(deviceID, name, ipAddress, status)
        {
        }
    }
}
