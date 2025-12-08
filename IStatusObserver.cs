namespace IoTDeviceMonitor
{
    public interface IStatusObserver
    {
        void Update(Device device, DeviceStatus oldStatus, DeviceStatus newStatus);
    }
}
