package problem8_MilitaryElite;

import problem8_MilitaryElite.contracts.*;
import problem8_MilitaryElite.models.*;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        Map<Integer, Soldier> soldiers = new LinkedHashMap<>();
        while (true) {
            String line = reader.readLine();
            if (line.equals("End")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");

            Soldier soldier = null;
            String type = lineArgs[0];
            int id = Integer.valueOf(lineArgs[1]);
            String firstName = lineArgs[2];
            String lastName = lineArgs[3];
            if (type.equals("Private")) {
                double salary = Double.valueOf(lineArgs[4]);
                soldier = new PrivateSoldierImpl(id, firstName, lastName, salary);
            } else if (type.equals("LeutenantGeneral")) {
                double salary = Double.valueOf(lineArgs[4]);
                Set<PrivateSoldier> privateSoldiers = new HashSet<>();
                for (int i = 5; i < lineArgs.length; i++) {
                    int privateSoldierId = Integer.valueOf(lineArgs[i]);
                    privateSoldiers.add((PrivateSoldier) soldiers.get(privateSoldierId));
                }

                soldier = new LeutanantGeneralmpl(id, firstName, lastName, salary, privateSoldiers);
            } else if (type.equals("Engineer")) {
                double salary = Double.valueOf(lineArgs[4]);
                String corps = lineArgs[5];

                Set<Repair> repairs = new HashSet<>();
                for (int i = 6; i < lineArgs.length; i += 2) {
                    String partName = lineArgs[i];
                    int workHours = Integer.valueOf(lineArgs[i + 1]);
                    Repair repair = new RepairImpl(partName, workHours);
                    repairs.add(repair);
                }

                try {
                    soldier = new EngineerImpl(id, firstName, lastName, salary, corps, repairs);
                } catch (IllegalArgumentException ex) {
                    // Invalid corps. We skip the soldier.
                    continue;
                }
            } else if (type.equals("Commando")) {
                double salary = Double.valueOf(lineArgs[4]);
                String corps = lineArgs[5];

                Set<Mission> missions = new HashSet<>();
                for (int i = 6; i < lineArgs.length; i += 2) {
                    String codeName = lineArgs[i];
                    String state = lineArgs[i + 1];
                    Mission mission;
                    try {
                        mission = new MissionImpl(codeName, state);
                    } catch (IllegalArgumentException ex) {
                        // Invalid mission state. We skip the mission.
                        continue;
                    }

                    missions.add(mission);
                }

                try {
                    soldier = new CommandoImpl(id, firstName, lastName, salary, corps, missions);
                } catch (IllegalArgumentException ex) {
                    // Invalid corps. We skip the soldier.
                    continue;
                }
            } else if (type.equals("Spy")) {
                try {
                    Integer codeNumber = Integer.valueOf(lineArgs[4]);
                    soldier = new SpyImpl(id, firstName, lastName, codeNumber.toString());
                } catch (Exception ex) {
                    String codeNumber = lineArgs[4];
                    soldier = new SpyImpl(id, firstName, lastName, codeNumber);
                }
            }

            soldiers.put(id, soldier);
        }

        for (Map.Entry<Integer, Soldier> soldier : soldiers.entrySet()) {
            System.out.println(soldier.getValue());
        }
    }
}