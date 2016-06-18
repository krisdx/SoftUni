package regularExpressions;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem9_QueryMess {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Pattern pattern = Pattern.compile("(.+)=(.+)");
        while (true) {
            String line = scanner.nextLine();
            if (line.equals("END")) {
                break;
            }

            Map<String, List<String>> map = new LinkedHashMap<>();

            String[] queries = line.split("[&?]");
            for (int i = 0; i < queries.length; i++) {
                String currentQuery = queries[i].replaceAll("%20", " ");
                currentQuery = currentQuery.replaceAll("\\+", " ");
                currentQuery = currentQuery.replaceAll("\\s+", " ");
                Matcher matcher = pattern.matcher(currentQuery);
                while (matcher.find()) {
                    String field = matcher.group(1).trim();
                    String value = matcher.group(2).trim();
                    if (!map.containsKey(field)) {
                        map.put(field, new ArrayList<>());
                    }

                    map.get(field).add(value);
                }
            }

            for (Map.Entry<String, List<String>> entry : map.entrySet()) {
                System.out.printf("%s=%s", entry.getKey(), entry.getValue());
            }
            System.out.println();
        }
    }
}