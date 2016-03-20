import java.util.ArrayList;
import java.util.Scanner;

public class GetAverage {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Enter 3 numbers, each on a separate line..");

        ArrayList<Double> numbers = new ArrayList<Double>();
        for (int i = 0; i < 3; i++) {
            numbers.add(input.nextDouble());
        }

        System.out.printf("Average: %.2f",Average(numbers));
    }

    private static double Average(ArrayList<Double> numbers) {
        double sum = 0;
        for (int i = 0; i < numbers.size(); i++) {
            sum += numbers.get(i);
        }

        return sum / numbers.size();
    }
}