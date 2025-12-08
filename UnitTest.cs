using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IoTDeviceMonitor;

namespace IoTDeviceMonitorTests
{
    [TestClass]
    public class DeviceManagerTests
    {
        private DeviceManager deviceManager;

        [TestInitialize]
        public void Setup()
        {
            deviceManager = new DeviceManager();
            // Clear any existing devices for clean tests
            // Assuming we can access private fields or provide a method to clear, but for simplicity, we'll add and test
        }

        [TestMethod]
        public void AddDevice_ValidDevice_ReturnsTrue()
        {
            // Arrange
            Device device = new Device("D001", "TestDevice", "192.168.1.1");

            // Act
            bool result = deviceManager.AddDevice(device);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddDevice_DuplicateId_ReturnsFalse()
        {
            // Arrange
            Device device1 = new Device("D001", "TestDevice1", "192.168.1.1");
            Device device2 = new Device("D001", "TestDevice2", "192.168.1.2");
            deviceManager.AddDevice(device1);

            // Act
            bool result = deviceManager.AddDevice(device2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveDevice_ExistingDevice_ReturnsTrue()
        {
            // Arrange
            Device device = new Device("D001", "TestDevice", "192.168.1.1");
            deviceManager.AddDevice(device);

            // Act
            bool result = deviceManager.RemoveDevice("D001");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveDevice_NonExistingDevice_ReturnsFalse()
        {
            // Act
            bool result = deviceManager.RemoveDevice("D999");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateDeviceStatus_ExistingDevice_ReturnsTrue()
        {
            // Arrange
            Device device = new Device("D001", "TestDevice", "192.168.1.1");
            deviceManager.AddDevice(device);

            // Act
            bool result = deviceManager.UpdateDeviceStatus("D001", DeviceStatus.Online);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateDeviceStatus_NonExistingDevice_ReturnsFalse()
        {
            // Act
            bool result = deviceManager.UpdateDeviceStatus("D999", DeviceStatus.Online);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SearchDeviceById_ExistingDevice_ReturnsDevice()
        {
            // Arrange
            Device device = new Device("D001", "TestDevice", "192.168.1.1");
            deviceManager.AddDevice(device);

            // Act
            Device result = deviceManager.SearchDeviceById("D001");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("D001", result.DeviceID);
        }

        [TestMethod]
        public void SearchDeviceById_NonExistingDevice_ReturnsNull()
        {
            // Act
            Device result = deviceManager.SearchDeviceById("D999");

            // Assert
            Assert.IsNull(result);
        }
    }
}
