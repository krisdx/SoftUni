package problem5_SpeedRacing;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedHashMap;
import java.util.Map;

public class Problem5_Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        Map<String, Car> cars = new LinkedHashMap<>();

        int n = Integer.valueOf(reader.readLine());
        for (int i = 0; i < n; i++) {
            String[] lineArgs = reader.readLine().split("\\s+");
            String model = lineArgs[0];
            double fuelAmount = Double.valueOf(lineArgs[1]);
            double fuelForOneKilometer = Double.valueOf(lineArgs[2]);

            Car car = new Car(model, fuelAmount, fuelForOneKilometer);
            cars.put(model, car);
        }

        while (true) {
            String line = reader.readLine();
            if (line.equals("End")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            String model = lineArgs[1];
            double targetDistance = Double.valueOf(lineArgs[2]);
            boolean canMove = cars.get(model).tryMove(targetDistance);
            if (!canMove) {
                System.out.println("Insufficient fuel for the drive");
            }
        }

        for (Map.Entry<String, Car> car : cars.entrySet()) {
            System.out.println(car.getValue().toString());
        }
    }
}

