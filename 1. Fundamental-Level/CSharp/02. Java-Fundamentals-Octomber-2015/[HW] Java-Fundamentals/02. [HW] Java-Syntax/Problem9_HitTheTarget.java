import java.util.Scanner;

public class Problem9_HitTheTarget {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.print("target = ");
        int target = input.nextInt();
        for (int i = 1; i <= 20; i++) {
            for (int j = 1; j <= 20; j++) {
                if (i + j == target){
                    System.out.printf("%s + %s = %s\n", i, j, target);
                }
            }
        }

        System.out.println("------------");

        for (int i = 20; i >= 1 ; i--) {
            for (int j = 20; j >= 1 ; j--) {
                if (i - j == target){
                    System.out.printf("%s - %s = %s\n", i, j, target);
                }
            }
        }
    }
}