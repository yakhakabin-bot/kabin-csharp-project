using System;

namespace IoTDeviceMonitor
{
    public enum DeviceStatus
    {
        Online,
        Offline,
        Maintenance
    }

    public class Device
    {
        public string DeviceID { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        private DeviceStatus _status;
        public DeviceStatus Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    DeviceStatus oldStatus = _status;
                    _status = value;
                    // Notify observers will be handled by DeviceManager
                }
            }
        }

        // Parameterless constructor required for JSON deserialization
        public Device()
        {
            DeviceID = string.Empty;
            Name = string.Empty;
            IPAddress = string.Empty;
            _status = DeviceStatus.Offline;
        }

        public Device(string deviceID, string name, string ipAddress, DeviceStatus status = DeviceStatus.Offline)
        {
            DeviceID = deviceID;
            Name = name;
            IPAddress = ipAddress;
            _status = status;
        }

        public override string ToString()
        {
            return $"ID: {DeviceID}, Name: {Name}, IP: {IPAddress}, Status: {Status}";
        }
    }
}
