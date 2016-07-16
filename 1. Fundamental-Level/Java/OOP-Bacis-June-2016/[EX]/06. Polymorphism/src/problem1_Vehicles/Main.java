package problem1_Vehicles;

import problem1_Vehicles.models.*;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    private static Car car;
    private static Truck truck;
    private static Bus bus;

    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String[] carParams = reader.readLine().split("\\s+");
        double carFuelQuantity = Double.valueOf(carParams[1]);
        double carFuelEconomy = Double.valueOf(carParams[2]);
        double carTankCapacity = Double.valueOf(carParams[3]);
        car = new Car(carFuelQuantity, carFuelEconomy, carTankCapacity);

        String[] truckParams = reader.readLine().split("\\s+");
        double truckFuelQuantity = Double.valueOf(truckParams[1]);
        double truckFuelEconomy = Double.valueOf(truckParams[2]);
        double truckTankCapacity = Double.valueOf(truckParams[3]);
        truck = new Truck(truckFuelQuantity, truckFuelEconomy, truckTankCapacity);

        String[] busParams = reader.readLine().split("\\s+");
        double busFuelQuantity = Double.valueOf(busParams[1]);
        double busFuelEconomy = Double.valueOf(busParams[2]);
        double busTankCapacity = Double.valueOf(busParams[3]);
        bus = new Bus(busFuelQuantity, busFuelEconomy, busTankCapacity);

        int n = Integer.valueOf(reader.readLine());
        for (int i = 0; i < n; i++) {
            String[] params = reader.readLine().split("\\s+");
            String command = params[0];
            String type = params[1];
            double num = Double.valueOf(params[2]);

            switch (command){
                case "Drive":
                    executeDriveCommand(type, num);
                    break;

                case "DriveEmpty":
                    executeDriveEmptyCommand(num);
                    break;

                case "Refuel":
                    executeRefuelCommand(type, num);
                    break;
            }
        }

        System.out.println(car);
        System.out.println(truck);
        System.out.println(bus);
    }

    private static void executeDriveEmptyCommand(double distance) {
        try{
            System.out.println(bus.driveEmpty(distance));
        } catch (IllegalArgumentException ex){
            System.out.println(ex.getMessage());
        }
    }

    private static void executeRefuelCommand(String type, double fuel) {
        try {
            switch (type) {
                case "Car":
                    car.refuel(fuel);
                    break;
                case "Truck":
                    truck.refuel(fuel);
                    break;
                case "Bus":
                    bus.refuel(fuel);
                    break;
            }
        } catch (IllegalArgumentException ex){
            System.out.println(ex.getMessage());
        }
    }

    private static void executeDriveCommand(String type, double distance) {
        try {
            switch (type) {
                case "Car":
                    System.out.println(car.drive(distance));
                    break;
                case "Truck":
                    System.out.println(truck.drive(distance));
                    break;
                case "Bus":
                    System.out.println(bus.drive(distance));
                    break;
            }
        } catch (IllegalArgumentException ex){
            System.out.println(ex.getMessage());
        }
    }
}