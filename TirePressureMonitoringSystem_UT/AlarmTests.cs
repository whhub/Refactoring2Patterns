using Microsoft.VisualStudio.TestTools.UnitTesting;
using TirePressureMonitoringSystem;

namespace TirePressureMonitoringSystem_UT
{
    [TestClass]
    public class AlarmTests
    {
        // TODO-new-feature: a normal pressure value after a value outside the range should stop the alarm
        // TODO-user-intent-test-Working-on: a pressure value outside the range should raise the alarm
        // TODO-user-intent-test: a normal pressure value after a value outside the range should not stop the alarm
        [TestMethod]
        public void A_normal_pressure_value_should_not_raise_the_alarm()
        {
            // Arrange
            StubSensor stubSensor = new StubSensor();
            stubSensor.ArrangeNextPressurePsiValue(Alarm.LowPressureThreshold);
            Alarm alarm = new Alarm(stubSensor);

            // Act
            alarm.Check();

            // Assert
            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestMethod]
        public void A_pressure_value_outside_the_range_should_raise_the_alarm()
        {
            // Arrange
            StubSensor stubSensor = new StubSensor();
            stubSensor.ArrangeNextPressurePsiValue(Alarm.HighPressureThreshold + 1);
            Alarm alarm = new Alarm(stubSensor);

            // Act
            alarm.Check();

            // Assert
            Assert.IsTrue(alarm.AlarmOn);
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