package manualStringProcessing;

import java.util.Scanner;

public class Problem2_StringLength {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String str = scanner.nextLine();
        if (str.length() < 20) {
            System.out.print(str);
            int count = 20 - str.length();
            for (int i = 0; i < count; i++) {
                System.out.print('*');
            }
        } else {
            System.out.println(str);
        }
    }
}
