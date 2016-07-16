import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Problem7_CarSalesman {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        Map<String, CarEngine> engines = new HashMap<>();

        int enginesCount = Integer.valueOf(reader.readLine());
        for (int i = 0; i < enginesCount; i++) {
            String[] lineArgs = reader.readLine().split("\\s+");
            String model = lineArgs[0];
            int power = Integer.valueOf(lineArgs[1]);
            CarEngine engine = new CarEngine(model, power);
            if (lineArgs.length == 3) {
                setValue(engine, lineArgs[2]);
            } else if (lineArgs.length == 4) {
                setValue(engine, lineArgs[2]);
                setValue(engine, lineArgs[3]);
            }

            engines.put(model, engine);
        }

        int carsCount = Integer.valueOf(reader.readLine());
        List<Car2> cars = new ArrayList<>();
        for (int i = 0; i < carsCount; i++) {
            String[] lineArgs = reader.readLine().split("\\s+");
            String model = lineArgs[0];
            CarEngine engine = engines.get(lineArgs[1]);
            Car2 car = new Car2(model, engine);
            if (lineArgs.length == 3) {
                setValue(car, lineArgs[2]);
            } else if (lineArgs.length == 4) {
                setValue(car, lineArgs[2]);
                setValue(car, lineArgs[3]);
            }

            cars.add(car);
        }

        cars.forEach(System.out::println);
    }

    private static void setValue(Car2 car, String value) {
        try {
            int weight = Integer.valueOf(value);
            car.setWidth(weight);
        } catch (NumberFormatException ex) {
            car.setColor(value);
        }
    }

    private static void setValue(CarEngine engine, String value) {
        try {
            int displacement = Integer.valueOf(value);
            engine.setDisplacement(displacement);
        } catch (NumberFormatException ex) {
            engine.setEfficiency(value);
        }
    }
}

class CarEngine {
    private String model;
    private int power;
    private Integer displacement;
    private String efficiency;

    public CarEngine(String model, int power) {
        this.model = model;
        this.power = power;
    }

    public void setDisplacement(int displacement) {
        this.displacement = displacement;
    }

    public void setEfficiency(String efficiency) {
        this.efficiency = efficiency;
    }

    @Override
    public String toString() {
        String displacement = this.displacement == null ?
                "n/a" : this.displacement.toString();
        String efficiency = this.efficiency == null ?
                "n/a" : this.efficiency;

        return String.format("  %s:%n" +
                        "   Power: %d%n" +
                        "   Displacement: %s%n" +
                        "   Efficiency: %s%n",
                this.model, this.power, displacement, efficiency);
    }
}

class Car2 {
    private String model;
    private CarEngine engine;
    private Integer width;
    private String color;

    public Car2(String model, CarEngine engine) {
        this.model = model;
        this.engine = engine;
    }

    public void setWidth(int width) {
        this.width = width;
    }

    public void setColor(String color) {
        this.color = color;
    }

    @Override
    public String toString() {
        String width = this.width == null ?
                "n/a" : this.width.toString();
        String color = this.color == null ?
                "n/a" : this.color;

        return String.format("%s: %n" +
                        "%s" +
                        "  Weight: %s%n" +
                        "  Color: %s",
                this.model, this.engine.toString(), width, color);
    }
}