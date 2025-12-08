using System;
using System.Collections.Generic;
using System.IO;

namespace IoTDeviceMonitor
{
    public class Report
    {
        private IReportStrategy _strategy;

        public void SetStrategy(IReportStrategy strategy)
        {
            _strategy = strategy;
        }

        public string GenerateReport(List<Device> devices)
        {
            if (_strategy == null)
            {
                return "No report strategy set.";
            }
            return _strategy.GenerateReport(devices);
        }

        public void ExportReport(List<Device> devices, string filePath)
        {
            try
            {
                string report = GenerateReport(devices);
                File.WriteAllText(filePath, report);
                Logger.Instance.Log($"Report exported to {filePath}");
            }
            catch (Exception ex)
            {
                Logger.Instance.Log($"Error exporting report: {ex.Message}");
            }
        }
    }
}
