package problem6_CustomEnumAnnotation;

import java.lang.annotation.Annotation;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String type = scanner.nextLine();
        if (type.equalsIgnoreCase("rank")) {
            Annotation annotation = Rank.class.getAnnotation(CustomEnumAnnotation.class);
            CustomEnumAnnotation rankAnnotation = (CustomEnumAnnotation) annotation;
            System.out.printf("Type = %s, Description = %s%n",
                    rankAnnotation.type(),
                    rankAnnotation.description());
        } else {
            Annotation annotation = Suit.class.getAnnotation(CustomEnumAnnotation.class);
            CustomEnumAnnotation suitAnnotation = (CustomEnumAnnotation) annotation;
            System.out.printf("Type = %s, Description = %s%n",
                    suitAnnotation.type(),
                    suitAnnotation.description());
        }
    }
}