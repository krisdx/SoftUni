import java.util.Scanner;

public class Problem4_FirefightingOrganization {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int fireFighters = Integer.parseInt(input.nextLine());

        int kidsSaved = 0;
        int adultsSaved = 0;
        int seniorsSaved = 0;
        String peopleInBuilding = input.nextLine();
        while (!peopleInBuilding.equals("rain") &&
                !peopleInBuilding.equals(null) &&
                !peopleInBuilding.equals("")) {

            int tempFireFighters = fireFighters;

            if (peopleInBuilding.length() <= tempFireFighters) {
                for (int i = 0; i < peopleInBuilding.length(); i++) {
                    switch (peopleInBuilding.charAt(i)) {
                        case 'K':
                            kidsSaved++;
                            break;
                        case 'A':
                            adultsSaved++;
                            break;
                        case 'S':
                            seniorsSaved++;
                            break;
                    }
                }
            } else {
                for (int i = 0; i < peopleInBuilding.length(); i++) {
                    if (tempFireFighters == 0) {
                        break;
                    }
                    if (peopleInBuilding.charAt(i) == 'K') {
                        kidsSaved++;
                        tempFireFighters--;
                    }
                }
                for (int i = 0; i < peopleInBuilding.length(); i++) {
                    if (tempFireFighters == 0) {
                        break;
                    }
                    if (peopleInBuilding.charAt(i) == 'A') {
                        adultsSaved++;
                        tempFireFighters--;
                    }
                }
                for (int i = 0; i < peopleInBuilding.length(); i++) {
                    if (tempFireFighters == 0) {
                        break;
                    }
                    if (peopleInBuilding.charAt(i) == 'S') {
                        seniorsSaved++;
                        tempFireFighters--;
                    }
                }
            }

            peopleInBuilding = input.nextLine();
        }

        System.out.printf("Kids: %s\n", kidsSaved);
        System.out.printf("Adults: %s\n", adultsSaved);
        System.out.printf("Seniors: %s\n", seniorsSaved);
    }
}