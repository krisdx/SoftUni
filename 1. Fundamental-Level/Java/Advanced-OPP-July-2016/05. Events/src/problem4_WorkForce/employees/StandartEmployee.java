package problem4_WorkForce.employees;

public class StandartEmployee extends AbstractEmployee {

    private static final int STANDARD_EMPLOYEE_WORK_HOURS_PER_WEEK = 40;

    public StandartEmployee(String name) {
        super(name, STANDARD_EMPLOYEE_WORK_HOURS_PER_WEEK);
    }
}