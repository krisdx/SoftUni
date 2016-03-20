import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem1_TinySporebat {

    private static final int STARTING_HEALTH_POINTS = 5800;

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Pattern pattern = Pattern.compile("(.+)(\\d)");

        int healthPoints = STARTING_HEALTH_POINTS;
        int totalGlowCapsCollected = 0;
        while (true) {
            String inputLine = input.nextLine();
            if (inputLine.equals("Sporeggar")) {
                break;
            }

            Matcher matcher = pattern.matcher(inputLine);
            if (matcher.find()) {
                String enemies = matcher.group(1);
                if (!enemies.equals(null) && !enemies.equals("")) {
                    for (int i = 0; i < enemies.length(); i++) {
                        if (enemies.charAt(i) == 'L') {
                            healthPoints += 200;
                            continue;
                        }

                        healthPoints -= enemies.charAt(i);
                        if (healthPoints <= 0) {
                            System.out.println("Died. Glowcaps: " + totalGlowCapsCollected);
                            return;
                        }
                    }
                }

                if (!matcher.group(2).equals(null) && !matcher.group(2).equals("")) {
                    totalGlowCapsCollected += Integer.parseInt(matcher.group(2));
                }
            }
        }

        System.out.println("Health left: " + healthPoints);
        if (totalGlowCapsCollected >= 30) {
            System.out.println("Bought the sporebat. Glowcaps left: " + (totalGlowCapsCollected - 30));
        } else {
            System.out.printf("Safe in Sporeggar, but another %d Glowcaps needed.", Math.abs(totalGlowCapsCollected - 30));
        }
    }
}