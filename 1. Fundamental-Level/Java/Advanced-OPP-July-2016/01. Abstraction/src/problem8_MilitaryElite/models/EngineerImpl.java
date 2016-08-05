package problem8_MilitaryElite.models;

import problem8_MilitaryElite.contracts.Engineer;
import problem8_MilitaryElite.contracts.Repair;

import java.util.Collection;
import java.util.Set;

public class EngineerImpl extends SpecialisedSoldierImpl implements Engineer {
    private Set<Repair> repairs;

    public EngineerImpl(int id,
                        String firstName,
                        String lastName,
                        double salary,
                        String corps,
                        Set<Repair> repairs) {
        super(id, firstName, lastName, salary, corps);
        this.repairs = repairs;
    }

    @Override
    public Collection<Repair> getRepairs() {
        return this.repairs;
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder(super.toString());

        output.append(System.lineSeparator())
                .append("Repairs: ");
        for (Repair repair : this.repairs) {
            output.append(System.lineSeparator());
            output.append("  ").append(repair.toString());
        }

        return output.toString().trim();
    }
}