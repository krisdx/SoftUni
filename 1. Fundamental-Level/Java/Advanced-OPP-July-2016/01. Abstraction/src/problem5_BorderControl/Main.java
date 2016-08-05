package problem5_BorderControl;

import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Map<String, List<Soldier>> soldiers = new HashMap<>();
        List<String> ids = new ArrayList<>();

        while (true) {
            String line = scanner.nextLine();
            if (line.equals("End")) {
                break;
            }

            String[] lineArgs = line.split(" ");
            Soldier soldier = null;
            if (lineArgs.length == 2) {
                String model = lineArgs[0];
                String id = lineArgs[1];
                soldier = new Robot(id, model);

                ids.add(id);

                addSoldier(soldiers, soldier, id);
            } else if (lineArgs.length == 3) {
                String name = lineArgs[0];
                int age = Integer.valueOf(lineArgs[1]);
                String id = lineArgs[2];
                soldier = new Citizen(id, name, age);

                addSoldier(soldiers, soldier, id);
                ids.add(id);
            }
        }

        String fakeId = scanner.nextLine();

        for (String id : ids) {
            if (id.endsWith(fakeId)) {
                System.out.println(id);
            }
        }
//        List<String> fakeIds = new ArrayList<>();
//        for (Map.Entry<String, List<Soldier>> soldier : soldiers.entrySet()) {
//            if (soldier.getKey().endsWith(fakeId)) {
//                for (Soldier s : soldier.getValue()) {
//                    fakeIds.add(s.getId());
//                }
//            }
//        }
//
//        for (String id : fakeIds) {
//            System.out.println(id);
//        }
    }

    private static void addSoldier(Map<String, List<Soldier>> soldiers, Soldier soldier, String id) {
        if (!soldiers.containsKey(id)) {
            soldiers.put(id, new ArrayList<>());
        }

        soldiers.get(id).add(soldier);
    }
}
