import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Problem3_TemperatureConverter {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        while (true) {
            String line = reader.readLine();
            if (line.equals("End")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            if (lineArgs[1].equals("Celsius")) {
                double result = Converter.fromFahrenheitToCelsius(
                        Integer.valueOf(lineArgs[0]));
                System.out.printf("%.2f Fahrenheit%n", result);

            } else {
                double result = Converter.fromCelsiusToFahrenheit(
                        Integer.valueOf(lineArgs[0]));
                System.out.printf("%.2f Celsius%n", result);
            }
        }
    }
}

class Converter {
    public static double fromCelsiusToFahrenheit(int value) {
        return (value - 32) / 1.8;
    }

    public static double fromFahrenheitToCelsius(int value) {
        return (value * 1.8) + 32;
    }
}