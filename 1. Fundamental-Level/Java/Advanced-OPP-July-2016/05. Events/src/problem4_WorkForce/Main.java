package problem4_WorkForce;

import problem4_WorkForce.contracts.Employee;
import problem4_WorkForce.employees.PartTimeEmployee;
import problem4_WorkForce.employees.StandartEmployee;

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

        Map<String, Employee> employees = new LinkedHashMap<>();
        CustomJobCollection jobCollection = new CustomJobCollection();
        while (true) {
            String line = reader.readLine();
            if (line.equalsIgnoreCase("end")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            String command = lineArgs[0];
            if (command.equalsIgnoreCase("job")) {
                String nameOfJob = lineArgs[1];
                int hoursRequired = Integer.valueOf(lineArgs[2]);
                String employeeName = lineArgs[3];
                Employee employee = employees.get(employeeName);

                JobImpl job = new JobImpl(nameOfJob, hoursRequired, employee, jobCollection);
                jobCollection.addJob(job);
            } else if (command.equalsIgnoreCase("standartemployee")) {
                String employeeName = lineArgs[1];
                Employee employee = new StandartEmployee(employeeName);

                employees.put(employeeName, employee);
            } else if (command.equalsIgnoreCase("parttimeemployee")) {
                String employeeName = lineArgs[1];
                Employee employee = new PartTimeEmployee(employeeName);

                employees.put(employeeName, employee);
            } else if (command.equalsIgnoreCase("pass")) {
                jobCollection.updateJobs();
            } else if (command.equalsIgnoreCase("status")) {
                jobCollection.getJobs().forEach(System.out::println);
            }
        }
    }
}