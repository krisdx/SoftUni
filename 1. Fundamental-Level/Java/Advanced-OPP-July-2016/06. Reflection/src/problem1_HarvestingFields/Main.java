package problem1_HarvestingFields;

import java.lang.reflect.Field;
import java.lang.reflect.Modifier;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) throws ReflectiveOperationException {
        Scanner scanner = new Scanner(System.in);

        while (true) {
            String line = scanner.nextLine();
            if (line.equalsIgnoreCase("harvest")) {
                break;
            }

            if (line.equalsIgnoreCase("private")) {

                Field[] fields = RichSoilLand.class.getDeclaredFields();
                printFields(fields, Modifier.PRIVATE);

            } else if (line.equalsIgnoreCase("protected")) {

                Field[] fields = RichSoilLand.class.getDeclaredFields();
                printFields(fields, Modifier.PROTECTED);

            } else if (line.equalsIgnoreCase("public")) {

                Field[] fields = RichSoilLand.class.getDeclaredFields();
                printFields(fields, Modifier.PUBLIC);

            } else if (line.equalsIgnoreCase("all")) {

                Field[] fields = RichSoilLand.class.getDeclaredFields();
                printFields(fields);
            }
        }
    }

    private static void printFields(Field[] fields) {
        for (Field field : fields) {
            String modifier = Modifier.toString(field.getModifiers());
            String type = field.getType().getSimpleName();
            String fieldName = field.getName();

            System.out.printf("%s %s %s%n", modifier, type, fieldName);
        }
    }

    private static void printFields(Field[] fields, int targetModifier) {
        for (Field field : fields) {
            if (field.getModifiers() == targetModifier) {
                String modifier = Modifier.toString(field.getModifiers());
                String type = field.getType().getSimpleName();
                String fieldName = field.getName();

                System.out.printf("%s %s %s%n", modifier, type, fieldName);
            }
        }
    }
}