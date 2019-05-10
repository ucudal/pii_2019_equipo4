using System;

namespace Temperatura
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TemperatureMonitor monitor = new TemperatureMonitor();
            TemperatureReporter reporter = new TemperatureReporter();
            monitor.Subscribe(reporter);
            monitor.GetTemperature();
        }
    }
}
