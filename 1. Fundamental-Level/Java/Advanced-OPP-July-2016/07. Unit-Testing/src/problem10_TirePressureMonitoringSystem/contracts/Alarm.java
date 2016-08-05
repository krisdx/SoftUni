package problem10_TirePressureMonitoringSystem.contracts;

public interface Alarm {

    double LOW_PRESSURE_THRESHOLD = 17;
    double HIGH_PRESSURE_THRESHOLD = 21;

    boolean isAlarmOn();

    void check();
}