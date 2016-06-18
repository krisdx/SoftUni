package setsAndMaps;

import java.util.*;

public class Problem11_LogsAggregator {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Map<String, UserInfo> logInfo = new TreeMap<>();

        // Pattern pattern = Pattern.compile("([.\\d]+)\\s+([a-zA-Z]+)\\s+(\\d+)");
        int n = Integer.parseInt(input.nextLine());
        for (int i = 0; i < n; i++) {
            String[] info = input.nextLine().split(" ");
            String IP = info[0];
            String name = info[1];
            int duration = Integer.valueOf(info[2]);
            UserInfo userInfo = new UserInfo(duration, IP);
            if (!logInfo.containsKey(name)) {
                logInfo.put(name, userInfo);
            } else {
                UserInfo newUserInfo = logInfo.get(name);
                newUserInfo.IPs.add(IP);
                newUserInfo.duration += duration;

                logInfo.put(name, newUserInfo);
            }
        }

        for (Map.Entry<String, UserInfo> userInfo : logInfo.entrySet()) {
            System.out.printf("%s: %s ", userInfo.getKey(), userInfo.getValue().duration);
            userInfo.getValue().printIPs();
        }
    }
}

class UserInfo {
    public UserInfo(Integer duration, String IP) {
        this.duration = duration;
        this.IPs.add(IP);
    }

    public Set<String> IPs = new TreeSet<>();
    public Integer duration;

    public void printIPs() {
        System.out.printf("[%s]\n", String.join(", ", this.IPs));
    }
}