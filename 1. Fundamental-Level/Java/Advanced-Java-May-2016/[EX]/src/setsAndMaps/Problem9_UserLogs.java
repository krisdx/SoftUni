package setsAndMaps;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem9_UserLogs {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Pattern pattern = Pattern.compile("IP=([\\d\\w.:]+)\\s+message='(.*)'\\s+user=(.+)");

        Map<String, Map<String, Integer>> usersInfo = new TreeMap<>();
        while (true) {
            String inputLine = input.nextLine();
            if (inputLine.equals("end")) {
                break;
            }

            Matcher matcher = pattern.matcher(inputLine);
            matcher.find();
            String IP = matcher.group(1);
            String user = matcher.group(3);

            if (!usersInfo.containsKey(user)) {
                usersInfo.put(user, new LinkedHashMap<>());
            }
            if (!usersInfo.get(user).containsKey(IP)) {
                usersInfo.get(user).put(IP, 1);
            } else {
                int currentMessageCount = usersInfo.get(user).get(IP);
                usersInfo.get(user).put(IP, currentMessageCount + 1);
            }
        }

        for (Map.Entry<String, Map<String, Integer>> user : usersInfo.entrySet()) {
            System.out.println(user.getKey() + ": ");
            int count = user.getValue().size() - 1;
            for (Map.Entry<String, Integer> messagesInfo : user.getValue().entrySet()) {
                if (count == 0) {
                    System.out.printf("%s => %s.", messagesInfo.getKey(), messagesInfo.getValue());
                } else {
                    System.out.printf("%s => %s, ", messagesInfo.getKey(), messagesInfo.getValue());
                }
                count--;
            }
            System.out.println();
        }
    }
}