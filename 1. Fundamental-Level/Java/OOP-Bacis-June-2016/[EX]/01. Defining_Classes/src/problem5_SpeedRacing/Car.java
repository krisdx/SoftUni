package problem5_SpeedRacing;

public class Car {
    private String model;
    private double fuel;
    private double fuelForOneKilometer;
    private int distanceTraveled;

    public Car(String model, double fuel, double fuelForOneKilometer) {
        this.model = model;
        this.fuel = fuel;
        this.fuelForOneKilometer = fuelForOneKilometer;
    }

    public boolean tryMove(double desiredDistance) {
        double requiredFuel = desiredDistance * fuelForOneKilometer;
        if (this.fuel >= requiredFuel) {
            this.distanceTraveled += desiredDistance;
            this.fuel -= desiredDistance * fuelForOneKilometer;
            return true;
        }

        return false;
    }

    @Override
    public String toString() {
        return String.format("%s %.2f %d", this.model, this.fuel, this.distanceTraveled);
    }
}