package problem2_BlackBoxInteger;

import problem2_BlackBoxInteger.com.peshoslav.BlackBoxInt;

import java.lang.reflect.Constructor;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) throws ReflectiveOperationException {
        Scanner scanner = new Scanner(System.in);

        Constructor constructor = BlackBoxInt.class.getDeclaredConstructor();
        constructor.setAccessible(true);
        BlackBoxInt blackBoxInt = (BlackBoxInt) constructor.newInstance();
        while (true) {
            String line = scanner.nextLine();
            if (line.equalsIgnoreCase("end")) {
                break;
            }

            String[] lineArgs = line.split("_");
            String methodName = lineArgs[0];
            int value = Integer.valueOf(lineArgs[1]);

            Method method = blackBoxInt.getClass().getDeclaredMethod(methodName, int.class);
            method.setAccessible(true);
            method.invoke(blackBoxInt, value);

            Field innerValue = blackBoxInt.getClass().getDeclaredField("innerValue");
            innerValue.setAccessible(true);
            System.out.println(innerValue.getInt(blackBoxInt));
        }
    }
}