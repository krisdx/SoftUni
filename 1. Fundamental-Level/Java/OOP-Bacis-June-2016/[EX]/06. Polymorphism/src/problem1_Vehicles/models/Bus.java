package problem1_Vehicles.models;

public class Bus extends Vehicle{

    public Bus(double fuelQuantity, double fuelEconomy, double tankCapacity) {
        super(fuelQuantity, fuelEconomy, tankCapacity);
    }


    public String drive(double distance) {
        double DRIVING_WITH_PEOPLE_ADITION = 1.4;
        return super.drive(distance, DRIVING_WITH_PEOPLE_ADITION);
    }

    public String driveEmpty(double distance){
        return super.drive(distance, 0);
    }
}
