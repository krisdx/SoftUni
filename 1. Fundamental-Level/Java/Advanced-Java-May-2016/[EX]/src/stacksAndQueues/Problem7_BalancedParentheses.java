package stacksAndQueues;

import java.util.*;

public class Problem7_BalancedParentheses {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Stack<Character> allParentheses = new Stack<>();

        String parentheses = input.nextLine();
        for (int i = 0; i < parentheses.length(); i++) {
            char currentParenthesis = parentheses.charAt(i);
            if (currentParenthesis == '{' ||
                    currentParenthesis == '(' ||
                    currentParenthesis == '[') {
                allParentheses.add(currentParenthesis);
            } else {
                if (allParentheses.size() == 0){
                    System.out.println("NO");
                    return;
                }

                char openParenthesis = allParentheses.pop();
                if ((openParenthesis == '(' && currentParenthesis != ')') ||
                        (openParenthesis == '[' && currentParenthesis != ']') ||
                        (openParenthesis == '{' && currentParenthesis != '}')) {
                    System.out.println("NO");
                    return;
                }
            }

        }

        System.out.println("YES");
    }
}