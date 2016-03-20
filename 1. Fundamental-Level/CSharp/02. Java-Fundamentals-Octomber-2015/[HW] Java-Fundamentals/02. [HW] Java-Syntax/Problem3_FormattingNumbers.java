import java.util.Scanner;

public class Problem3_FormattingNumbers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.print("a = ");
        int a = Integer.parseInt(input.next());
        while (0 > a || a > 500) {
            System.out.println("Try again");
            a = Integer.parseInt(input.next());
        }
        System.out.print("b = ");
        double b = Double.parseDouble(input.next());
        System.out.print("c = ");
        double c = Double.parseDouble(input.next());

        System.out.printf("|%-10X|%-10d|%10.2f|%-10.3f|\n",
                a, Integer.parseInt(Integer.toBinaryString(a)), b, c);
    }
}