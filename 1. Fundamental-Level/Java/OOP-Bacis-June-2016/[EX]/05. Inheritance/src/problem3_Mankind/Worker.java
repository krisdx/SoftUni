package problem3_Mankind;

public class Worker extends Human {
    private double weekSalary;
    private double workHoursPerDay;

    public Worker(String firstName, String lastName, double weekSalary, double workHoursPerDay) {
        super(firstName, lastName);
        this.setWeekSalary(weekSalary);
        this.setWorkHoursPerDay(workHoursPerDay);
    }

    private void setWeekSalary(double weekSalary) {
        if (weekSalary < 10) {
            throw new IllegalArgumentException("Expected value mismatch!Argument: weekSalary");
        }

        this.weekSalary = weekSalary;
    }

    private void setWorkHoursPerDay(double workHoursPerDay) {
        if (workHoursPerDay < 1 || workHoursPerDay > 12) {
            throw new IllegalArgumentException("Expected value mismatch!Argument: workHoursPerDay");
        }

        this.workHoursPerDay = workHoursPerDay;
    }

    private double calculateSalaryPerHour() {
        return this.weekSalary / (7 * this.workHoursPerDay);
    }

    @Override
    public String toString() {
        return super.toString() +
                "Week Salary: " + String.format("%.2f", this.weekSalary) + System.lineSeparator() +
                "Hours per day: " + String.format("%.2f", this.workHoursPerDay) + System.lineSeparator() +
                "Salary per hour: " + String.format("%.2f", this.calculateSalaryPerHour()) + System.lineSeparator();
    }
}