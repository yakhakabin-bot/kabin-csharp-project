using System;

namespace IoTDeviceMonitor
{
    class Program
    {
        static DeviceManager deviceManager = new DeviceManager();
        static Report report = new Report();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to IoT Device Monitor System");
            Logger.Instance.Log("Application started.");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Device");
                Console.WriteLine("2. Remove Device");
                Console.WriteLine("3. Update Device Status");
                Console.WriteLine("4. Search Device by ID");
                Console.WriteLine("5. Search Device by Name");
                Console.WriteLine("6. List All Devices");
                Console.WriteLine("7. Sort Devices by Name");
                Console.WriteLine("8. Sort Devices by Status");
                Console.WriteLine("9. Generate Status Report");
                Console.WriteLine("10. Generate Health Report");
                Console.WriteLine("11. Export Report");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddDevice();
                        break;
                    case "2":
                        RemoveDevice();
                        break;
                    case "3":
                        UpdateDeviceStatus();
                        break;
                    case "4":
                        SearchDeviceById();
                        break;
                    case "5":
                        SearchDeviceByName();
                        break;
                    case "6":
                        ListAllDevices();
                        break;
                    case "7":
                        SortDevicesByName();
                        break;
                    case "8":
                        SortDevicesByStatus();
                        break;
                    case "9":
                        GenerateStatusReport();
                        break;
                    case "10":
                        GenerateHealthReport();
                        break;
                    case "11":
                        ExportReport();
                        break;
                    case "0":
                        running = false;
                        Logger.Instance.Log("Application exited.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddDevice()
        {
            Console.Write("Enter Device ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter Device Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter IP Address: ");
            string ip = Console.ReadLine();
            Console.Write("Enter Device Type (1: Generic, 2: TemperatureSensor, 3: MotionSensor): ");
            string typeChoice = Console.ReadLine();

            Device device = null;
            switch (typeChoice)
            {
                case "1":
                    device = new Device(id, name, ip);
                    break;
                case "2":
                    device = new TemperatureSensor(id, name, ip);
                    break;
                case "3":
                    device = new MotionSensor(id, name, ip);
                    break;
                default:
                    Console.WriteLine("Invalid type. Creating generic device.");
                    device = new Device(id, name, ip);
                    break;
            }

            if (deviceManager.AddDevice(device))
            {
                Console.WriteLine("Device added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add device. Device ID may already exist.");
            }
        }

        static void RemoveDevice()
        {
            Console.Write("Enter Device ID to remove: ");
            string id = Console.ReadLine();
            if (deviceManager.RemoveDevice(id))
            {
                Console.WriteLine("Device removed successfully.");
            }
            else
            {
                Console.WriteLine("Device not found.");
            }
        }

        static void UpdateDeviceStatus()
        {
            Console.Write("Enter Device ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter new status (0: Online, 1: Offline, 2: Maintenance): ");
            string statusChoice = Console.ReadLine();

            DeviceStatus status;
            switch (statusChoice)
            {
                case "0":
                    status = DeviceStatus.Online;
                    break;
                case "1":
                    status = DeviceStatus.Offline;
                    break;
                case "2":
                    status = DeviceStatus.Maintenance;
                    break;
                default:
                    Console.WriteLine("Invalid status.");
                    return;
            }

            if (deviceManager.UpdateDeviceStatus(id, status))
            {
                Console.WriteLine("Device status updated successfully.");
            }
            else
            {
                Console.WriteLine("Device not found.");
            }
        }

        static void SearchDeviceById()
        {
            Console.Write("Enter Device ID: ");
            string id = Console.ReadLine();
            Device device = deviceManager.SearchDeviceById(id);
            if (device != null)
            {
                Console.WriteLine(device.ToString());
            }
            else
            {
                Console.WriteLine("Device not found.");
            }
        }

        static void SearchDeviceByName()
        {
            Console.Write("Enter Device Name: ");
            string name = Console.ReadLine();
            var devices = deviceManager.SearchDeviceByName(name);
            if (devices.Count > 0)
            {
                foreach (var device in devices)
                {
                    Console.WriteLine(device.ToString());
                }
            }
            else
            {
                Console.WriteLine("No devices found.");
            }
        }

        static void ListAllDevices()
        {
            var devices = deviceManager.GetAllDevices();
            if (devices.Count > 0)
            {
                foreach (var device in devices)
                {
                    Console.WriteLine(device.ToString());
                }
            }
            else
            {
                Console.WriteLine("No devices found.");
            }
        }

        static void SortDevicesByName()
        {
            deviceManager.SortDevicesByName();
            Console.WriteLine("Devices sorted by name.");
        }

        static void SortDevicesByStatus()
        {
            deviceManager.SortDevicesByStatus();
            Console.WriteLine("Devices sorted by status.");
        }

        static void GenerateStatusReport()
        {
            report.SetStrategy(new StatusReport());
            string reportText = report.GenerateReport(deviceManager.GetAllDevices());
            Console.WriteLine(reportText);
        }

        static void GenerateHealthReport()
        {
            report.SetStrategy(new HealthReport());
            string reportText = report.GenerateReport(deviceManager.GetAllDevices());
            Console.WriteLine(reportText);
        }

        static void ExportReport()
        {
            Console.Write("Enter report type (1: Status, 2: Health): ");
            string typeChoice = Console.ReadLine();
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            if (typeChoice == "1")
            {
                report.SetStrategy(new StatusReport());
            }
            else if (typeChoice == "2")
            {
                report.SetStrategy(new HealthReport());
            }
            else
            {
                Console.WriteLine("Invalid type.");
                return;
            }

            report.ExportReport(deviceManager.GetAllDevices(), filePath);
            Console.WriteLine("Report exported.");
        }
    }
}
