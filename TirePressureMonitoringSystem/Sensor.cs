using System;

namespace TirePressureMonitoringSystem
{
    public class Sensor : Transducer
    {
        //
        // The reading of the pressure value from the sensor is simulated in this implementation.
        // Because the focus of the exercise is on the other class.
        //

        private const double Offset = 16;
        private readonly Random _randomPressureSampleSimulator = new Random();

        #region [--Implement from Transducer--]

        public double PopNextPressurePsiValue()
        {
            var pressureTelemetryValue = ReadPressureSample();

            return Offset + pressureTelemetryValue;
        }

        #endregion

        private double ReadPressureSample()
        {
            // Simulate info read from a real sensor in a real tire
            return 6*_randomPressureSampleSimulator.NextDouble()*_randomPressureSampleSimulator.NextDouble();
        }
    }
}