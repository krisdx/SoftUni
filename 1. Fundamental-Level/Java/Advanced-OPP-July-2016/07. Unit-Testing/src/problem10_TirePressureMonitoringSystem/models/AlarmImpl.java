package problem10_TirePressureMonitoringSystem.models;

import problem10_TirePressureMonitoringSystem.contracts.Alarm;
import problem10_TirePressureMonitoringSystem.contracts.Sensor;

public class AlarmImpl implements Alarm {

    private Sensor sensor;
    private boolean alarmOn;

    public AlarmImpl(Sensor sensor) {
        this.sensor = sensor;
    }

    @Override
    public void check() {
        double psiPressureValue =
                this.sensor.popNextPressurePsiValue();

        if (psiPressureValue < LOW_PRESSURE_THRESHOLD ||
                HIGH_PRESSURE_THRESHOLD < psiPressureValue) {
            this.alarmOn = true;
        }
    }

    @Override
    public boolean isAlarmOn() {
        return this.alarmOn;
    }
}