using System;

namespace IoTDeviceMonitor
{
    public class MotionSensor : Device
    {
        public MotionSensor(string deviceID, string name, string ipAddress, DeviceStatus status = DeviceStatus.Offline)
            : base(deviceID, name, ipAddress, status)
        {
        }
    }
}
