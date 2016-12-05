namespace TirePressureMonitoringSystem
{
    public class Alarm
    {
        public const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;
        // TODO: Depending on a concrete Sensor violates the Dependency Inversion Principle and Open-Closed Principle
        private readonly Sensor _sensor = new Sensor();
        public bool AlarmOn { get; private set; }

        public void Check()
        {
            var psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                AlarmOn = true;
            }
        }
    }
}