package problem8_ShapesVolume;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Problem8_Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        while (true) {
            String line = reader.readLine();
            if (line.equals("End")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            if (lineArgs[0].equals("Cube")) {
                Cube cube = new Cube(Double.valueOf(lineArgs[1]));
                System.out.printf("%.3f%n", VolumeCalculator.calcVolume(cube));
            } else if (lineArgs[0].equals("Cylinder")) {
                Cylinder cylinder = new Cylinder(Double.valueOf(lineArgs[1]), Double.valueOf(lineArgs[2]));
                System.out.printf("%.3f%n", VolumeCalculator.calcVolume(cylinder));
            } else {
                TriangularPrism triangularPrism = new TriangularPrism(
                        Double.valueOf(lineArgs[1]),
                        Double.valueOf(lineArgs[2]),
                        Double.valueOf(lineArgs[3]));
                System.out.printf("%.3f%n", VolumeCalculator.calcVolume(triangularPrism));
            }
        }
    }
}