import java.util.Scanner;

public class CharacterTriangle {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();

        for (int i = 1; i <= n ; i++) {
            char ch = 'a';
            for (int j = 0; j < i; j++) {
                System.out.printf("%s ", ch++);
            }
            System.out.println();
        }
        for (int i = n - 1; i >= 0 ; i--) {
            char ch = 'a';
          for (int j = i - 1; j >= 0; j--) {
               System.out.printf("%s ", ch++);
            }
            System.out.println();
        }
    }
}