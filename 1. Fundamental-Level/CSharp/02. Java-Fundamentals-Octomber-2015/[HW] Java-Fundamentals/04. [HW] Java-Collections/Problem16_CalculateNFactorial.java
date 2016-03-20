import java.util.Scanner;

public class Problem16_CalculateNFactorial {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();

        System.out.printf("%s! = %s", n, recursivelyCalculateFactorial(n));
    }

    private static int recursivelyCalculateFactorial(int n) {
        if (n == 0) {
            return 1;
        } else {
            return n * recursivelyCalculateFactorial(n - 1);
        }
    }
}