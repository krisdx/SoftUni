import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Problem6_RawData {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        List<Car> cars = new ArrayList<>();
        int n = Integer.valueOf(reader.readLine());
        for (int i = 0; i < n; i++) {
            String[] lineArgs = reader.readLine().split("\\s+");
            String model = lineArgs[0];

            int engineSpeed = Integer.valueOf(lineArgs[1]);
            int enginePower = Integer.valueOf(lineArgs[2]);
            Engine engine = new Engine(engineSpeed, enginePower);

            String cargoType = lineArgs[4];
            int cargoWeight = Integer.valueOf(lineArgs[3]);
            Cargo cargo = new Cargo(cargoType, cargoWeight);

            int firstTireAge = Integer.valueOf(lineArgs[6]);
            double firstTirePressure = Double.valueOf(lineArgs[5]);
            Tire firstTire = new Tire(firstTireAge, firstTirePressure);

            int secondTireAge = Integer.valueOf(lineArgs[8]);
            double secondTirePressure = Double.valueOf(lineArgs[7]);
            Tire secondTire = new Tire(secondTireAge, secondTirePressure);

            int thirdTireAge = Integer.valueOf(lineArgs[10]);
            double thirdTirePressure = Double.valueOf(lineArgs[9]);
            Tire thirdTire = new Tire(thirdTireAge, thirdTirePressure);

            int fourthTireAge = Integer.valueOf(lineArgs[12]);
            double fourthTirePressure = Double.valueOf(lineArgs[11]);
            Tire fourthTire = new Tire(fourthTireAge, fourthTirePressure);

            Tire[] tires = new Tire[]{firstTire, secondTire, thirdTire, fourthTire};

            Car car = new Car(model, engine, cargo, tires);
            cars.add(car);
        }

        String command = reader.readLine();
        if (command.equals("fragile")) {
            cars.stream()
                    .filter(c -> c.getCargo().getCargoType().equals("fragile"))
                    .filter(Car::hasTirePressureLessThanOne)
                    .forEach(System.out::println);
        } else {
            cars.stream()
                    .filter(c -> c.getCargo().getCargoType().equals("flamable"))
                    .filter(c -> c.getEngine().getEnginePower() > 250)
                    .forEach(System.out::println);
        }
    }
}

class Car {
    private String model;
    private Engine engine;
    private Cargo cargo;
    private Tire[] tires;

    public Car(String model, Engine engine, Cargo cargo, Tire[] tires) {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }

    public boolean hasTirePressureLessThanOne() {
        for (Tire tire : this.tires) {
            if (tire.getFirstTirePressure() < 1) {
                return true;
            }
        }

        return false;
    }

    public Cargo getCargo() {
        return this.cargo;
    }

    public Engine getEngine() {
        return this.engine;
    }

    @Override
    public String toString() {
        return this.model;
    }
}

class Cargo {
    private String cargoType;
    private int cargoWeight;

    public Cargo(String cargoType, int cargoWeight) {
        this.cargoType = cargoType;
        this.cargoWeight = cargoWeight;
    }

    public String getCargoType() {
        return this.cargoType;
    }
}

class Engine {
    private int engineSpeed;
    private int enginePower;

    public Engine(int engineSpeed, int enginePower) {
        this.engineSpeed = engineSpeed;
        this.enginePower = enginePower;
    }

    public int getEnginePower() {
        return this.enginePower;
    }
}

class Tire {
    private int firstTireAge;
    private double firstTirePressure;

    public Tire(int firstTireAge, double firstTirePressure) {
        this.firstTireAge = firstTireAge;
        this.firstTirePressure = firstTirePressure;
    }

    public double getFirstTirePressure() {
        return this.firstTirePressure;
    }
}