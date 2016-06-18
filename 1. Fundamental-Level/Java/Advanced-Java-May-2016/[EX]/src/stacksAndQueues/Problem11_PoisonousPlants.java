package stacksAndQueues;

import java.util.*;

public class Problem11_PoisonousPlants {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String str = "543";
        int left = 0;
        int right = str.length() - 1;
        char[] result  = new char[str.length()];
        while (left <= right){
            result[left] = str.charAt(right);
            result[right] = str.charAt(left);
            left++;
            right--;
        }
        for (char c : result) {
            System.out.print(c);
        }

        int n = input.nextInt();
        Deque<Plant> plants = new ArrayDeque<>(n);
        for (int i = 1; i <= n; i++) {
            int pesticide = input.nextInt();
            Plant plant = new Plant(pesticide, i);
            plants.add(plant);
        }

        int daysCount = 0;
        while (true) {
            boolean stoppedDying = true;
            Deque<Plant> alivePlants = new ArrayDeque<>();
            int count = plants.size();
            while (count > 1) {
                Plant leftPlant = plants.remove();
                Plant rightPlant = plants.peek();

                if (leftPlant.pesticide < rightPlant.pesticide) {
                    rightPlant.isAlive = false;
                    stoppedDying = false;
                }

                if (leftPlant.isAlive) {
                    alivePlants.add(leftPlant);
                }

                count--;
            }

            if (stoppedDying) {
                break;
            }

            if (plants.peekLast().isAlive) {
                alivePlants.add(plants.peekLast());
            }

            plants = alivePlants;
            daysCount++;
        }

        System.out.println(daysCount);
    }
}

class Plant {
    public Plant(long pesticide, int position) {
        this.pesticide = pesticide;
        this.position = position;
        this.isAlive = true;
    }

    public long pesticide;
    public int position;
    public boolean isAlive;
}