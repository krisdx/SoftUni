package problem9_TrafficLights;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        String[] lights = reader.readLine().split("\\s+");
        int n = Integer.valueOf(reader.readLine());
        for (int i = 0; i < n; i++) {
            incrementLights(lights);
            printLights(lights);
        }
    }

    private static void incrementLights(String[] lights) {
        for (int i = 0; i < lights.length; i++) {
            if (lights[i].equals(TrafficLight.RED.name())) {
                lights[i] = TrafficLight.GREEN.name();
            } else if (lights[i].equals(TrafficLight.GREEN.name())) {
                lights[i] = TrafficLight.YELLOW.name();
            } else if (lights[i].equals(TrafficLight.YELLOW.name())) {
                lights[i] = TrafficLight.RED.name();
            }
        }
    }

    private static void printLights(String[] lights) {
        for (String light : lights) {
            System.out.print(light + " ");
        }

        System.out.println();
    }
}