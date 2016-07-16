import com.sun.org.apache.bcel.internal.classfile.ClassFormatException;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.reflect.Method;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class Problem9_PizzaTime {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        String lineArgs = reader.readLine();

        Map<Integer, List<String>> pizzas = proceedPizzas(lineArgs);
        for (Map.Entry<Integer, List<String>> p : pizzas.entrySet()) {
            System.out.printf(p.getKey() + " - ");
            System.out.println(String.join(", ", p.getValue()));
        }

        Class<?> pizzaClass = Pizza.class;
        Method[] methods = pizzaClass.getDeclaredMethods();
        List<Method> checkedMethods = Arrays.stream(methods)
                .filter(m -> m.getReturnType().getName().contains("Map"))
                .collect(Collectors.toList());

        if (checkedMethods.size() < 1) {
            throw new ClassFormatException();
        }
    }

    public static Map<Integer, List<String>> proceedPizzas(String line) {
        Map<Integer, List<String>> map = new TreeMap<>();

        Pattern pattern = Pattern.compile("(\\d+)([a-zA-Z0-9]+)");
        Matcher matcher = pattern.matcher(line);
        while (matcher.find()) {
            Integer group = Integer.valueOf(matcher.group(1));
            String pizzaName = matcher.group(2);

            if (!map.containsKey(group)) {
                map.put(group, new ArrayList<>());
            }

            map.get(group).add(pizzaName);
        }

        return map;
    }
}

class Pizza {
    private String name;
    private int group;

    public Pizza(int group, String name) {
        this.group = group;
        this.name = name;
    }

    public Map<Integer, String> getPizza() {
        Map<Integer, String> groupAndName = new HashMap<>();
        groupAndName.put(this.group, this.name);
        return groupAndName;
    }
}