import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Problem8_CarTrip {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        String[] lineArgs = reader.readLine().split("\\s+");
        int speed = Integer.valueOf(lineArgs[0]);
        int fuel = Integer.valueOf(lineArgs[1]);
        int fuelEconomy = Integer.valueOf(lineArgs[2]);
        Car car = new Car(speed, fuel, fuelEconomy);

        while (true) {
            String[] commandArgs = reader.readLine().split("\\s+");
            String command = commandArgs[0];
            if (command.equals("Travel")) {
                int distance = Integer.valueOf(commandArgs[1]);
                car.travel(distance);
            } else if (command.equals("Refuel")) {
                int liters = Integer.valueOf(commandArgs[1]);
                car.refuel(liters);
            } else if (command.equals("Distance")) {
                System.out.printf("Total distance: %.1f kilometers%n", car.getTotalDistanceTraveled());
            } else if (command.equals("Time")) {
                String totalTimeTraveled = car.getTotalTimeTraveled();
                System.out.println(totalTimeTraveled);
            } else if (command.equals("Fuel")) {
                double fuelLeft = car.getFuel();
                System.out.printf("Fuel left: %.1f liters%n", fuelLeft);
            } else {
                break;
            }
        }
    }
}

class Car {
    private double speed;
    private double fuel;
    private double fuelEconomy;

    private double totalDistanceTraveled;

    public Car(int speed, int fuel, int fuelEconomy) {
        this.fuelEconomy = fuelEconomy;
        this.fuel = fuel;
        this.speed = speed;
    }

    public double getTotalDistanceTraveled() {
        return this.totalDistanceTraveled;
    }

    public void travel(int desiredDistance) {
        double requiredFuel = (this.fuelEconomy * desiredDistance) / speed;
        if (requiredFuel <= this.fuel) {
            this.totalDistanceTraveled += desiredDistance;
            this.fuel -= requiredFuel;
        } else {
            int totalHoursTraveled = (int) Math.round((this.fuel  * this.fuelEconomy) / this.speed);
            int totalMinutesTraveled = (int) Math.round((this.fuel  * this.fuelEconomy) % this.speed);

            this.totalDistanceTraveled += (this.speed * totalHoursTraveled) + (this.speed * totalMinutesTraveled);
            this.fuel = 0;
        }
    }

    public void refuel(int liters) {
        this.fuel += liters;
    }

    public String getTotalTimeTraveled() {
        int totalHoursTraveled = (int) Math.round(this.totalDistanceTraveled / this.speed);
        int totalMinutesTraveled = (int) Math.round(this.totalDistanceTraveled % this.speed);
        return String.format("Total time: %d hours and %d minutes", totalHoursTraveled, totalMinutesTraveled);
    }

    public double getFuel() {
        return this.fuel;
    }
}