# IoT Device Monitoring System

A comprehensive C# console application for monitoring and managing IoT devices with advanced design patterns, reporting capabilities, and persistent data storage.

## 🎯 Project Overview

The IoT Device Monitoring System is a desktop application built with .NET 8.0 that demonstrates enterprise-level design patterns and algorithms. It provides a complete solution for managing IoT devices, tracking their status, generating reports, and maintaining a persistent log of all operations.

### Key Features

- **Observer Pattern**: Real-time device status change monitoring with automatic observer notifications
- **Factory Pattern**: Dynamic device creation supporting multiple device types (Generic, TemperatureSensor, MotionSensor)
- **Strategy Pattern**: Flexible report generation with multiple report types (Status Report, Health Report)
- **Singleton Pattern**: Centralized logging system for application-wide logging
- **Data Persistence**: JSON-based device storage and TXT-based activity logging
- **Comprehensive Search**: Linear search and name-based device discovery
- **Sorting Algorithms**: Bubble sort implementation for device lists
- **Unit Testing**: MSTest framework with comprehensive test coverage
- **Error Handling**: Robust exception handling for file I/O and input validation

## 📋 Table of Contents

- [System Requirements](#system-requirements)
- [Installation & Setup](#installation--setup)
- [Running the Application](#running-the-application)
- [Running Unit Tests](#running-unit-tests)
- [Project Structure](#project-structure)
- [Design Patterns](#design-patterns)
- [Usage Guide](#usage-guide)
- [File Formats](#file-formats)
- [Architecture](#architecture)



### Prerequisites

1. Install .NET 8.0 SDK from [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/8.0)
2. Verify installation:
   ```powershell
   dotnet --version
   ```

## 📦 Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/yakhakabin-bot/kabin-csharp-project.git
cd kabin-csharp-project
```

### 2. Restore Dependencies

```bash
dotnet restore
```

This command will automatically download and install all required NuGet packages:
- `Newtonsoft.Json` (v13.0.3) - For JSON serialization/deserialization
- `MSTest.TestFramework` (v3.0.2) - For unit testing
- `MSTest.TestAdapter` (v3.0.2) - Test execution support

### 3. Build the Project

```bash
dotnet build
```

Expected output:
```
Build succeeded.
    0 Error(s)
    0 Warning(s)
```

## 🚀 Running the Application

### Quick Start

```bash
dotnet run
```

The application will start with an interactive console menu:

```
Welcome to IoT Device Monitor System

Menu:
1. Add Device
2. Remove Device
3. Update Device Status
4. Search Device by ID
5. Search Device by Name
6. List All Devices
7. Sort Devices by Name
8. Sort Devices by Status
9. Generate Status Report
10. Generate Health Report
11. Export Report
0. Exit
Choose an option:
```

### Complete Workflow Example

```bash
# Build and run
dotnet build
dotnet run

# Then in the application, perform these steps:
# 1. Select option 1 to add a device
#    - Device ID: D001
#    - Device Name: Server-01
#    - IP Address: 192.168.1.100
#    - Device Type: 1 (Generic)
#
# 2. Select option 6 to list all devices
# 3. Select option 3 to update device status
# 4. Select option 9 to generate status report
# 5. Select option 11 to export report to file
# 6. Select option 0 to exit
```

## 🧪 Running Unit Tests

### Run All Tests

```bash
dotnet test
```

Expected output:
```
Starting test execution, please wait...
A total of 1 test files matched the search pattern.

Passed!  - Failed:     0, Passed:     5, Skipped:     0
```

### Run Tests with Verbose Output

```bash
dotnet test --logger "console;verbosity=detailed"
```

### Run Specific Test Class

```bash
dotnet test --filter "ClassName=DeviceManagerTests"
```

### Generate Code Coverage Report

```bash
dotnet test /p:CollectCoverage=true /p:CoverageFormat=opencover
```

## 📂 Project Structure

```
kabin-csharp-project/
├── Device.cs                          # Core device class with status enumeration
├── DeviceManager.cs                   # Device management (add, remove, update, search, sort)
├── IStatusObserver.cs                 # Observer pattern interface
├── IReportStrategy.cs                 # Strategy pattern interface for reports
├── Logger.cs                          # Singleton logger for file-based logging
├── MotionSensor.cs                    # Motion sensor device type
├── TemperatureSensor.cs               # Temperature sensor device type
├── StatusReport.cs                    # Status report implementation
├── HealthReport.cs                    # Health report implementation
├── Report.cs                          # Report generation orchestrator
├── Program.cs                         # Main console application with menu
├── UnitTest.cs                        # Comprehensive unit tests (MSTest)
├── IoTDeviceMonitor.csproj            # Project configuration
├── devices.json                       # Persistent device storage
├── logs.txt                           # Application activity log
└── README.md                          # This file
```

## 🏗️ Design Patterns

### 1. **Observer Pattern** (IStatusObserver)
- Tracks device status changes
- Notifies observers when device status is updated
- Located in: `DeviceManager.cs`, `IStatusObserver.cs`

### 2. **Factory Pattern** (DeviceFactory)
- Creates different device types (Generic, TemperatureSensor, MotionSensor)
- Encapsulates device instantiation logic
- Located in: `Device.cs`

### 3. **Strategy Pattern** (IReportStrategy)
- Implements different report generation strategies
- StatusReport: Counts devices by status
- HealthReport: Shows device health percentage
- Located in: `IReportStrategy.cs`, `StatusReport.cs`, `HealthReport.cs`

### 4. **Singleton Pattern** (Logger)
- Single global logger instance
- Thread-safe access to logging functionality
- Logs to: `logs.txt`

## 📖 Usage Guide

### Adding a Device

1. Select option `1` from the main menu
2. Enter the device ID (unique identifier)
3. Enter the device name
4. Enter the IP address
5. Select device type:
   - `1` = Generic Device
   - `2` = Temperature Sensor
   - `3` = Motion Sensor
6. Device will be added to the system and stored in `devices.json`

### Removing a Device

1. Select option `2` from the main menu
2. Enter the device ID to remove
3. Device will be removed from the system

### Updating Device Status

1. Select option `3` from the main menu
2. Enter the device ID
3. Select new status:
   - `1` = Online
   - `2` = Offline
   - `3` = Maintenance

### Searching for Devices

**By ID (Linear Search)**:
1. Select option `4`
2. Enter device ID

**By Name (Linear Search)**:
1. Select option `5`
2. Enter device name (partial match supported)

### Listing All Devices

1. Select option `6`
2. All devices will be displayed with their details

### Sorting Devices

**By Name (Bubble Sort)**:
1. Select option `7`
2. Devices will be sorted alphabetically by name

**By Status (Bubble Sort)**:
1. Select option `8`
2. Devices will be sorted by status (Online → Offline → Maintenance)

### Generating Reports

**Status Report**:
1. Select option `9`
2. View count of devices by status

**Health Report**:
1. Select option `10`
2. View device health percentage and status

### Exporting Reports

1. Select option `11`
2. Enter file path where report should be saved
3. Report will be written to the specified file

## 📄 File Formats

### devices.json
Stores all devices in JSON format:
```json
[
  {
    "DeviceID": "D001",
    "Name": "Server-01",
    "IPAddress": "192.168.1.100",
    "Status": 0
  }
]
```

**Status Values**:
- `0` = Online
- `1` = Offline
- `2` = Maintenance


```

## 🏛️ Architecture

### Class Hierarchy

```
Device (Base Class)
├── MotionSensor (Extends Device)
└── TemperatureSensor (Extends Device)

DeviceManager
├── Maintains: List<Device> and Dictionary<string, Device>
├── Implements: Observer notification
└── Uses: IReportStrategy

Report
├── Uses: IReportStrategy (composition)
├── StatusReport (implements IReportStrategy)
└── HealthReport (implements IReportStrategy)

Logger (Singleton)
└── Writes to: logs.txt

IStatusObserver (Interface)
└── Implemented by: DeviceManager
```

### Data Flow

```
User Input (Console)
    ↓
Program (Menu Handler)
    ↓
DeviceManager (Business Logic)
    ├→ File I/O (devices.json)
    ├→ Observer Notification
    └→ Logger (logs.txt)
    ↓
Report/Strategy (If reporting)
    ↓
Console Output / File Export
```

## 🔧 Troubleshooting

### Build Errors

**Error**: "You must install or update .NET to run this application."
```bash
# Install .NET 8.0
dotnet --version
# If not 8.0.x, download from https://dotnet.microsoft.com/download/dotnet/8.0
```

**Error**: "Project file not found"
```bash
# Ensure you're in the project directory
cd kabin-csharp-project
dotnet build
```



## 📊 Test Coverage

The `UnitTest.cs` file includes comprehensive tests:

- ✅ **AddDevice_ValidDevice_ReturnsTrue** - Validates device addition
- ✅ **AddDevice_DuplicateId_ReturnsFalse** - Prevents duplicate IDs
- ✅ **RemoveDevice_ExistingDevice_ReturnsTrue** - Validates removal
- ✅ **UpdateDeviceStatus_ValidDevice_ReturnsTrue** - Status updates
- ✅ **SearchDeviceById_ExistingDevice_ReturnsDevice** - ID-based search

Run tests with:
```bash
dotnet test
```


## 📝 Development Notes

### Adding New Device Types

1. Create new class extending `Device`
2. Update `Program.cs` device type selection
3. Add tests to `UnitTest.cs`

### Adding New Report Types

1. Create class implementing `IReportStrategy`
2. Implement `GenerateReport(List<Device> devices)` method
3. Update `Program.cs` menu

### Extending Search Algorithms

- Current: Linear search O(n)
- Future: Binary search (requires sorted list)

## 📚 Technologies Used

- **Language**: C# (.NET 8.0)
- **JSON Library**: Newtonsoft.Json (v13.0.3)
- **Testing Framework**: MSTest (v3.0.2)
- **IDE**: Visual Studio / VS Code recommended
- **VCS**: Git

## 📄 License

This project is part of an educational assignment for IoT Device Monitoring System.

## 👨‍💻 Author

Created as a comprehensive demonstration of:
- Object-Oriented Programming (OOP)
- Design Patterns (Observer, Factory, Strategy, Singleton)
- Data Structures and Algorithms
- Unit Testing and Code Quality

## 🔗 Repository

**GitHub**: [yakhakabin-bot/kabin-csharp-project](https://github.com/yakhakabin-bot/kabin-csharp-project)

## ❓ FAQ

**Q: Can I run this on Linux/macOS?**
A: Yes! .NET 8.0 is cross-platform. Just ensure .NET 8.0 SDK is installed.

**Q: Where are devices saved?**
A: In `devices.json` in the project directory.

**Q: Can I modify the data files manually?**
A: Yes, `devices.json` is standard JSON. Be careful with formatting.

**Q: How do I clear all devices?**
A: Delete `devices.json` and restart the application.

**Q: Can I export reports in different formats?**
A: Currently TXT format. You can extend the Strategy pattern to support CSV, JSON, etc.

---

**Last Updated**: December 9, 2025  
**Version**: 1.0  
**Status**: Production Ready
