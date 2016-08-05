package problem4_WorkForce.employees;

public class PartTimeEmployee extends AbstractEmployee {

    private static final int PART_TIME_EMPLOYEE_WORK_HOURS_PER_WEEK = 20;

    public PartTimeEmployee(String name) {
        super(name, PART_TIME_EMPLOYEE_WORK_HOURS_PER_WEEK);
    }
}