import java.util.Scanner;

public class Problem1_RectangleArea {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        double a = Double.parseDouble(input.next());
        double b = Double.parseDouble(input.next());

        System.out.printf("Rectangle area: %s", a * b);
    }
}
