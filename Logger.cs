using System;
using System.IO;

namespace IoTDeviceMonitor
{
    public class Logger : IStatusObserver
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private readonly string _logFilePath = "logs.txt";

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }

        public void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging: {ex.Message}");
            }
        }

        public void Update(Device device, DeviceStatus oldStatus, DeviceStatus newStatus)
        {
            Log($"Device {device.DeviceID} status changed from {oldStatus} to {newStatus}");
        }
    }
}
