package stacksAndQueues;

import java.util.*;

public class Problem6_TruckTour {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int n = Integer.parseInt(input.nextLine());
        Deque<PetrolStation> queue = new ArrayDeque<>();

        for (int i = 0; i < n; i++) {
            String[] inputParams = input.nextLine().split(" ");
            long petrolAmount = Long.parseLong(inputParams[0]);
            long distanceToNextPump = Long.parseLong(inputParams[1]);
            PetrolStation petrolPump = new PetrolStation(petrolAmount, distanceToNextPump);

            queue.addLast(petrolPump);
        }

        int resultIndex = 0;
        boolean solutionFound = false;
        while (true) {
            PetrolStation startStation = queue.removeFirst();
            queue.addLast(startStation);

            long petrol = startStation.petrol;
            petrol -= startStation.distanceToNextPump;
            int currentStationsCount = 1;
            while (petrol >= 0) {
                PetrolStation currentStation = queue.removeFirst();
                if (currentStation == startStation) {
                    solutionFound = true;
                    break;
                }

                queue.addLast(currentStation);
                petrol += currentStation.petrol;
                petrol -= currentStation.distanceToNextPump;
                currentStationsCount++;
            }

            if (solutionFound) {
                break;
            }

            resultIndex += currentStationsCount;
        }

        System.out.println(resultIndex);
    }
}

class PetrolStation {
    public long petrol;
    public long distanceToNextPump;

    public PetrolStation(long petrol, long distanceToNextStation) {
        this.petrol = petrol;
        this.distanceToNextPump = distanceToNextStation;
    }
}