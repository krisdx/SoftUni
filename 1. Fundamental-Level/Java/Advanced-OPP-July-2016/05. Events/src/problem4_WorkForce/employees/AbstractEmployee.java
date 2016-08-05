package problem4_WorkForce.employees;

import problem4_WorkForce.contracts.Employee;

public abstract class AbstractEmployee implements Employee {

    private String name;
    private int workHoursPerWeek;

    public AbstractEmployee(String name, int workHoursPerWeek) {
        this.name = name;
        this.workHoursPerWeek = workHoursPerWeek;
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public int getWorkHoursPerWeek() {
        return this.workHoursPerWeek;
    }
}