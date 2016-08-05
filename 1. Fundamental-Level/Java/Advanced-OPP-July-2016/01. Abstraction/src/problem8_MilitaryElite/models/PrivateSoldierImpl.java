package problem8_MilitaryElite.models;

import problem8_MilitaryElite.contracts.PrivateSoldier;

public class PrivateSoldierImpl extends SoldierImpl implements PrivateSoldier {
    private double salary;

    public PrivateSoldierImpl(int id, String firstName, String lastName, double salary) {
        super(id, firstName, lastName);
        this.salary = salary;
    }

    @Override
    public double getSalary() {
        return this.salary;
    }

    @Override
    public String toString() {
        return super.toString() + String.format(" Salary: %.2f", this.salary);
    }
}