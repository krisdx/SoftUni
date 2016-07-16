package problem1_Vehicles.models;

import java.text.DecimalFormat;

abstract class Vehicle {
    private double fuelQuantity;
    private double fuelEconomy;
    private double tankCapacity;

    Vehicle(double fuelQuantity, double fuelEconomy, double tankCapacity) {
        this.setFuelQuantity(fuelQuantity);
        this.setFuelEconomy(fuelEconomy);
        this.setTankCapacity(tankCapacity);
    }

    double getFuelQuantity() {
        return fuelQuantity;
    }

    void setFuelQuantity(double fuelQuantity) {
        if (fuelQuantity < 0) {
            throw new IllegalArgumentException("Fuel must be a positive number");
        }
        this.fuelQuantity = fuelQuantity;
    }

    private void setFuelEconomy(double fuelEconomy) {
        this.fuelEconomy = fuelEconomy;
    }

    double getTankCapacity() {
        return tankCapacity;
    }

    private void setTankCapacity(double tankCapacity) {
        this.tankCapacity = tankCapacity;
    }

    String drive(double distance, double addition) {
        if ((this.fuelQuantity / (this.fuelEconomy + addition) < distance)) {
            throw new IllegalArgumentException(String.format("%s needs refueling", this.getClass().getSimpleName()));
        }

        this.fuelQuantity -= distance * (this.fuelEconomy + addition);
        DecimalFormat df = new DecimalFormat("0.######");
        return String.format("%s travelled %s km", this.getClass().getSimpleName(), df.format(distance));
    }

    public void refuel(double fuel) {
        if (this.fuelQuantity + fuel > this.tankCapacity) {
            throw new IllegalArgumentException("Cannot fit fuel in tank");
        }

        this.fuelQuantity += fuel;
    }

    @Override
    public String toString() {
        return String.format("%s: %.2f", this.getClass().getSimpleName(), this.fuelQuantity);
    }
}
