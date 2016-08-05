package problem10_TirePressureMonitoringSystem.tests;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.mockito.Mock;
import org.mockito.Mockito;
import problem10_TirePressureMonitoringSystem.contracts.Alarm;
import problem10_TirePressureMonitoringSystem.contracts.Sensor;
import problem10_TirePressureMonitoringSystem.models.AlarmImpl;

public class TirePressureSystem_Tests {

    private Alarm alarm;

    @Mock
    private Sensor mockSensor;

    @Before
    public void initialize() {
        this.mockSensor = Mockito.mock(Sensor.class);
        this.alarm = new AlarmImpl(this.mockSensor);
    }

    @Test
    public void alarmWithHighPressure_ShouldActivateAlarm() {
        // Act
        Mockito.when(this.mockSensor.popNextPressurePsiValue())
                .thenReturn(150.0);
        this.alarm.check();

        // Assert
        Assert.assertTrue(this.alarm.isAlarmOn());
    }

    @Test
    public void alarmWithNegativePressure_ShouldActivateAlarm() {
        // Act
        Mockito.when(this.mockSensor.popNextPressurePsiValue())
                .thenReturn(-18.0);
        this.alarm.check();

        // Assert
        Assert.assertTrue(this.alarm.isAlarmOn());
    }

    @Test
    public void alarmWithLessThanUpperBoundPressure_ShouldNotActivateAlarm() {
        // Act
        Mockito.when(this.mockSensor.popNextPressurePsiValue())
                .thenReturn(Alarm.HIGH_PRESSURE_THRESHOLD - 0.01);
        this.alarm.check();

        // Assert
        Assert.assertFalse(this.alarm.isAlarmOn());
    }

    @Test
    public void alarmWithMoreThanLowerBoundPressure_ShouldNotActivateAlarm() {
        // Act
        Mockito.when(this.mockSensor.popNextPressurePsiValue())
                .thenReturn(Alarm.LOW_PRESSURE_THRESHOLD + 0.01);
        this.alarm.check();

        // Assert
        Assert.assertFalse(this.alarm.isAlarmOn());
    }
}