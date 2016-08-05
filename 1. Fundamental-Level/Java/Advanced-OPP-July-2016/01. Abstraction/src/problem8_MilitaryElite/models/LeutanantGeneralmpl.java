package problem8_MilitaryElite.models;

import problem8_MilitaryElite.contracts.LeutanantGeneral;
import problem8_MilitaryElite.contracts.PrivateSoldier;

import java.util.Collection;
import java.util.Set;

public class LeutanantGeneralmpl extends PrivateSoldierImpl implements LeutanantGeneral {
    private Set<PrivateSoldier> privateSoldiers;

    public LeutanantGeneralmpl(
            int id,
            String firstName,
            String lastName,
            double salary,
            Set<PrivateSoldier> privateSoldiers) {
        super(id, firstName, lastName, salary);
        this.privateSoldiers = privateSoldiers;
    }

    @Override
    public Collection<PrivateSoldier> getPrivateSoldiers() {
        return this.privateSoldiers;
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder(super.toString());

        output.append(System.lineSeparator())
                .append("Privates: ");
        for (PrivateSoldier privateSoldier : this.privateSoldiers) {
            output.append(System.lineSeparator());
            output.append("  ").append(privateSoldier.toString());
        }

        return output.toString().trim();
    }
}