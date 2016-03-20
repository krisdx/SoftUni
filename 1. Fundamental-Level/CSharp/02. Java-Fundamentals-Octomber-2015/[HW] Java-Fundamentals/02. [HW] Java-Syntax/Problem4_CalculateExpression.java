import java.util.Scanner;

public class Problem4_CalculateExpression {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("a = ");
        double a = Double.parseDouble(input.next());
        System.out.print("b = ");
        double b = Double.parseDouble(input.next());
        System.out.print("c = ");
        double c = Double.parseDouble(input.next());

        double firstExpression =
                Math.pow(((a * a) + (b * b)) / ((a * a) - (b * b)),
                        (a + b + c) / Math.sqrt(c));
        double secondExpression =
                Math.pow((a * a) + (b * b) - (c * c * c), a - b);

        double result = ((a + b + c) / 3) - ((firstExpression + secondExpression) / 2);
        System.out.printf("F1 result: %.2f; F2 result: %.2f; Diff: %.2f",
                firstExpression, secondExpression, Math.abs(result));
    }
}
