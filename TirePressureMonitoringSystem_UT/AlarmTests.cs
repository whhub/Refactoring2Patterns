using Microsoft.VisualStudio.TestTools.UnitTesting;
using TirePressureMonitoringSystem;

namespace TirePressureMonitoringSystem_UT
{
    [TestClass]
    public class AlarmTests
    {
        // TODO-new-feature-working-on: a normal pressure value after a value outside the range should stop the alarm
        [TestMethod]
        public void A_normal_pressure_value_should_not_raise_the_alarm()
        {
            // Arrange
            StubSensor stubSensor = new StubSensor();
            Alarm alarm = new Alarm(stubSensor);

            // Act
            stubSensor.ArrangeNextPressurePsiValue(Alarm.LowPressureThreshold);
            alarm.Check();

            // Assert
            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestMethod]
        public void A_pressure_value_outside_the_range_should_raise_the_alarm()
        {
            // Arrange
            StubSensor stubSensor = new StubSensor();
            Alarm alarm = new Alarm(stubSensor);

            // Act
            stubSensor.ArrangeNextPressurePsiValue(Alarm.HighPressureThreshold + 1);
            alarm.Check();

            // Assert
            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod]
        public void A_normal_pressure_value_after_a_value_outside_the_range_should_stop_the_alarm()
        {
            // Arrange
            StubSensor stubSensor = new StubSensor();
            Alarm alarm = new Alarm(stubSensor);

            // Act
            stubSensor.ArrangeNextPressurePsiValue(Alarm.LowPressureThreshold - 1);
            alarm.Check();
            stubSensor.ArrangeNextPressurePsiValue(Alarm.LowPressureThreshold);
            alarm.Check();

            // Assert
            Assert.IsFalse(alarm.AlarmOn);
        }
    }

    public class StubSensor : Transducer
    {
        private double _nextPressurePsiValue;

        public void ArrangeNextPressurePsiValue(double nextPressureThreshold)
        {
            _nextPressurePsiValue = nextPressureThreshold;
        }

        #region Implementation of Transducer

        public double PopNextPressurePsiValue()
        {
            return _nextPressurePsiValue;
        }

        #endregion
    }
}