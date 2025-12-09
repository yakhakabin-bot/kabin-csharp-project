# IoT Device Monitoring System - TODO List

## Step 1: Create Core Classes
- [x] Create Device.cs: Define Device class with DeviceID, Name, IPAddress, Status. Implement INotifyPropertyChanged or similar for observer.
- [x] Create IStatusObserver.cs: Interface for observer pattern.
- [x] Create StatusObserver.cs: Concrete observer class (e.g., for logging status changes).
- [x] Create Logger.cs: Singleton logger class for logging to TXT file.

## Step 2: Create Factory and Manager
- [x] Create DeviceFactory.cs: Factory pattern to create different device types (e.g., TemperatureSensor, MotionSensor).
- [x] Create DeviceManager.cs: Manages devices with List and Dictionary. Implements add, remove, update, search (linear), sort (bubble sort). Notifies observers.

## Step 3: Create Report and Main Program
- [x] Create Report.cs: Report generation with Strategy pattern for different report types.
- [x] Create Program.cs: Console application with menu for user interaction. Load/save JSON data.

## Step 4: Add Persistence and Error Handling
- [x] Implement JSON persistence in DeviceManager (using Newtonsoft.Json).
- [x] Add TXT logging in Logger.
- [x] Add error handling throughout (try-catch for file I/O, input validation).

## Step 5: Unit Testing
- [x] Create UnitTest.cs: Unit tests for AddDevice, RemoveDevice, UpdateDeviceStatus, SearchDeviceById using MSTest.

## Step 6: Testing and Debugging
- [x] Run the application manually to test all functionalities.
- [x] Debug any issues using Visual Studio tools.
- [x] Ensure all requirements are met (OOP, patterns, algorithms, etc.).

## Step 7: GitHub Repository
- [x] Initialize Git repository locally.
- [x] Create initial commit with all project files.
- [x] Create GitHub repository and push code.
