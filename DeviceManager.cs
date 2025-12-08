using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace IoTDeviceMonitor
{
    public class DeviceManager
    {
        private List<Device> devices = new List<Device>();
        private Dictionary<string, Device> deviceDict = new Dictionary<string, Device>();
        private List<IStatusObserver> observers = new List<IStatusObserver>();
        private readonly string devicesFilePath = "devices.json";

        public DeviceManager()
        {
            observers.Add(Logger.Instance);
            LoadDevices();
        }

        public void AddObserver(IStatusObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IStatusObserver observer)
        {
            observers.Remove(observer);
        }

        private void NotifyObservers(Device device, DeviceStatus oldStatus, DeviceStatus newStatus)
        {
            foreach (var observer in observers)
            {
                observer.Update(device, oldStatus, newStatus);
            }
        }

        public bool AddDevice(Device device)
        {
            if (deviceDict.ContainsKey(device.DeviceID))
            {
                Logger.Instance.Log($"Failed to add device: DeviceID {device.DeviceID} already exists.");
                return false;
            }
            devices.Add(device);
            deviceDict[device.DeviceID] = device;
            Logger.Instance.Log($"Device added: {device.DeviceID}");
            SaveDevices();
            return true;
        }

        public bool RemoveDevice(string deviceID)
        {
            if (deviceDict.TryGetValue(deviceID, out Device device))
            {
                devices.Remove(device);
                deviceDict.Remove(deviceID);
                Logger.Instance.Log($"Device removed: {deviceID}");
                SaveDevices();
                return true;
            }
            Logger.Instance.Log($"Failed to remove device: DeviceID {deviceID} not found.");
            return false;
        }

        public bool UpdateDeviceStatus(string deviceID, DeviceStatus newStatus)
        {
            if (deviceDict.TryGetValue(deviceID, out Device device))
            {
                DeviceStatus oldStatus = device.Status;
                device.Status = newStatus;
                NotifyObservers(device, oldStatus, newStatus);
                Logger.Instance.Log($"Device status updated: {deviceID} to {newStatus}");
                SaveDevices();
                return true;
            }
            Logger.Instance.Log($"Failed to update device status: DeviceID {deviceID} not found.");
            return false;
        }

        public Device SearchDeviceById(string deviceID)
        {
            // Linear search
            foreach (var device in devices)
            {
                if (device.DeviceID == deviceID)
                {
                    return device;
                }
            }
            return null;
        }

        public List<Device> SearchDeviceByName(string name)
        {
            // Linear search
            List<Device> result = new List<Device>();
            foreach (var device in devices)
            {
                if (device.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(device);
                }
            }
            return result;
        }

        public void SortDevicesByName()
        {
            // Bubble Sort
            int n = devices.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(devices[j].Name, devices[j + 1].Name) > 0)
                    {
                        // Swap
                        Device temp = devices[j];
                        devices[j] = devices[j + 1];
                        devices[j + 1] = temp;
                    }
                }
            }
            Logger.Instance.Log("Devices sorted by name.");
        }

        public void SortDevicesByStatus()
        {
            // Bubble Sort
            int n = devices.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (devices[j].Status > devices[j + 1].Status)
                    {
                        // Swap
                        Device temp = devices[j];
                        devices[j] = devices[j + 1];
                        devices[j + 1] = temp;
                    }
                }
            }
            Logger.Instance.Log("Devices sorted by status.");
        }

        public List<Device> GetAllDevices()
        {
            return new List<Device>(devices);
        }

        private void LoadDevices()
        {
            try
            {
                if (File.Exists(devicesFilePath))
                {
                    string json = File.ReadAllText(devicesFilePath);
                    devices = JsonConvert.DeserializeObject<List<Device>>(json) ?? new List<Device>();
                    // Rebuild dictionary
                    deviceDict.Clear();
                    foreach (var device in devices)
                    {
                        deviceDict[device.DeviceID] = device;
                    }
                    Logger.Instance.Log("Devices loaded from file.");
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Log($"Error loading devices: {ex.Message}");
                devices = new List<Device>();
            }
        }

        private void SaveDevices()
        {
            try
            {
                string json = JsonConvert.SerializeObject(devices, Formatting.Indented);
                File.WriteAllText(devicesFilePath, json);
                Logger.Instance.Log("Devices saved to file.");
            }
            catch (Exception ex)
            {
                Logger.Instance.Log($"Error saving devices: {ex.Message}");
            }
        }
    }
}
