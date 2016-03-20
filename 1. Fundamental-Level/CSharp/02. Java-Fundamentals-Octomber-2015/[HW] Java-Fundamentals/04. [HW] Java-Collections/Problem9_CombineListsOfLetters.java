import java.util.ArrayList;
import java.util.Scanner;

public class Problem9_CombineListsOfLetters {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] firstCharSet = input.nextLine().split(" ");
        String[] secondCharSet = input.nextLine().split(" ");

        ArrayList<Character> joinedList  = new ArrayList<>();
        for (int i = 0; i < firstCharSet.length; i++) {
            joinedList.add(firstCharSet[i].charAt(0));
        }

        for (int i = 0; i < secondCharSet.length; i++) {
            if (!joinedList.contains(secondCharSet[i].charAt(0))) {
                joinedList.add(secondCharSet[i].charAt(0));
            }
        }

        System.out.println(joinedList);
    }
}