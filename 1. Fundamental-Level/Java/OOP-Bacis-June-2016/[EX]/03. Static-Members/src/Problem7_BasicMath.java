import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Problem7_BasicMath {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        while (true) {
            String line = reader.readLine();
            if (line.equals("End")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            String action = lineArgs[0];
            if (action.equals("Sum")) {
                double firstNum = Double.valueOf(lineArgs[1]);
                double secondNum = Double.valueOf(lineArgs[2]);
                System.out.printf("%.2f%n", MathUtil.sum(firstNum, secondNum));
            } else if (action.equals("Multiply")) {
                double firstNum = Double.valueOf(lineArgs[1]);
                double secondNum = Double.valueOf(lineArgs[2]);
                System.out.printf("%.2f%n", MathUtil.multiply(firstNum, secondNum));
            } else if (action.equals("Percentage")) {
                double totalNumber = Double.valueOf(lineArgs[1]);
                double percentage = Double.valueOf(lineArgs[2]);
                System.out.printf("%.2f%n", MathUtil.percentage(totalNumber, percentage));
            } else if (action.equals("Divide")) {
                double dividend = Double.valueOf(lineArgs[1]);
                double divisor = Double.valueOf(lineArgs[2]);
                System.out.printf("%.2f%n", MathUtil.divide(dividend, divisor));
            } else if (action.equals("Subtract")) {
                double firstNum = Double.valueOf(lineArgs[1]);
                double secondNum = Double.valueOf(lineArgs[2]);
                System.out.printf("%.2f%n", MathUtil.subtract(firstNum, secondNum));
            }
        }
    }
}

class MathUtil {
    public static double sum(double a, double b) {
        return a + b;
    }

    public static double subtract(double a, double b) {
        return a - b;
    }

    public static double divide(double dividend, double divisor) {
        return dividend / divisor;
    }

    public static double multiply(double a, double b) {
        return a * b;
    }

    public static double percentage(double totalNumber, double percentage) {
        return (percentage / 100) * totalNumber;
    }
}