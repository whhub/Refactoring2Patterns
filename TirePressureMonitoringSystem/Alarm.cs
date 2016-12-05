namespace TirePressureMonitoringSystem
{
    public class Alarm
    {
        public const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;
        // TODO-working-on: Depending on a concrete Sensor violates the Dependency Inversion Principle and Open-Closed Principle
        private Transducer _transducer;

        public Alarm()
        {
            _transducer = new Sensor();
        }

        public Alarm(Transducer transducer)
        {
            _transducer = transducer;
        }

        public bool AlarmOn { get; private set; }

        public void Check()
        {
            var psiPressureValue = _transducer.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                AlarmOn = true;
            }
        }
    }
}