namespace TirePressureMonitoringSystem
{
    public class Alarm
    {
        public const double LowPressureThreshold = 17;
        public const double HighPressureThreshold = 21;
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

            AlarmOn = false;

            var psiPressureValue = _transducer.PopNextPressurePsiValue();
            
            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                AlarmOn = true;
            }
        }
    }
}