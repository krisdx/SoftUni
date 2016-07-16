import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.*;

public class Problem4_Main {
    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        Map<String, DepartmentInfo> departments = new HashMap<>();
        Map<String, List<Employee>> employees = new HashMap<>();

        int n = Integer.valueOf(reader.readLine());
        for (int i = 0; i < n; i++) {
            String[] lineArgs = reader.readLine().split("\\s+");
            String name = lineArgs[0];
            double salary = Double.valueOf(lineArgs[1]);
            String position = lineArgs[2];
            String department = lineArgs[3];

            if (!departments.containsKey(department)) {
                departments.put(department, new DepartmentInfo(salary));
            } else {
                DepartmentInfo newDepartmentInfo = departments.get(department);
                newDepartmentInfo.setTotalSalaries(newDepartmentInfo.getTotalSalaries() + salary);
                departments.put(department, newDepartmentInfo);
            }

            Employee employee = new Employee(name, salary, position, department);
            if (lineArgs.length == 5) {
                setValue(lineArgs[4], employee);
            } else if (lineArgs.length == 6) {
                setValue(lineArgs[4], employee);
                setValue(lineArgs[5], employee);
            }

            if (!employees.containsKey(department)) {
                employees.put(department, new ArrayList<>());
            }

            employees.get(department).add(employee);
        }

        String bestDepartment = null;
        double bestAverageSalary = 0.0;
        for (Map.Entry<String, DepartmentInfo> department : departments.entrySet()) {
            double currentAverage = department.getValue().getAverageSalary();
            if (currentAverage > bestAverageSalary) {
                bestAverageSalary = currentAverage;
                bestDepartment = department.getKey();
            }
        }

        System.out.println("Highest Average Salary: " + bestDepartment);
        employees.get(bestDepartment)
                .stream()
                .sorted((x, y) -> y.getSalary().compareTo(x.getSalary()))
                .forEach(System.out::println);
    }

    private static void setValue(String value, Employee employee) {
        try {
            int age = Integer.valueOf(value);
            employee.setAge(age);
        } catch (Exception ex) {
            String email = value;
            employee.setEmail(email);
        }
    }
}

class Employee {
    private String name;
    private Double salary;
    private String position;
    private String department;
    private String email;
    private int age;

    public Employee(String name, double salary, String position, String department) {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = "n/a";
        this.age = -1;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public Double getSalary() {
        return this.salary;
    }

    @Override
    public String toString() {
        return String.format("%s %.2f %s %d", this.name, this.salary, this.email, this.age);
    }
}

class DepartmentInfo {
    private int count;
    private double totalSalaries;

    public DepartmentInfo(double initialSalary) {
        this.totalSalaries = initialSalary;
        this.count++;
    }

    public double getAverageSalary() {
        return totalSalaries / count;
    }

    public double getTotalSalaries() {
        return this.totalSalaries;
    }

    public void setTotalSalaries(double totalSalaries) {
        this.totalSalaries = totalSalaries;
        this.count++;
    }
}