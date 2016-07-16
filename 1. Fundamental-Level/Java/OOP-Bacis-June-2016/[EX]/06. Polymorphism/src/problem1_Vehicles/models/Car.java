package problem1_Vehicles.models;

public class Car extends Vehicle{

    public Car(double fuelQuantity, double fuelEconomy, double tankCapacity) {
        super(fuelQuantity, fuelEconomy, tankCapacity);
    }

    public String drive(double distance) {
        double SUMMER_CAR_FUEL_INCREASE = 0.9;
        return super.drive(distance, SUMMER_CAR_FUEL_INCREASE);
    }
}
