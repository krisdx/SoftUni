package problem10_TirePressureMonitoringSystem.models;

import problem10_TirePressureMonitoringSystem.contracts.Sensor;

import java.util.Random;

public class SensorImpl implements Sensor {
    // The reading of the pressure value from the sensor is simulated in this implementation.
    // Because the focus of the exercise is on the other class.

    private static final double OFFSET = 16;

    private static Random randomPressureSimulator = new Random();

    @Override
    public double popNextPressurePsiValue() {
        double pressureTelemetryValue = this.readPressureSample();
        return OFFSET + pressureTelemetryValue;
    }

    private double readPressureSample() {
        // Simulate info read from a real sensor in a real tire
        return 6 * randomPressureSimulator.nextDouble() *
                randomPressureSimulator.nextDouble();
    }
}