package problem8_MilitaryElite.models;

import problem8_MilitaryElite.contracts.SpecialisedSoldier;

public abstract class SpecialisedSoldierImpl extends PrivateSoldierImpl implements SpecialisedSoldier {

    private String corps;

    protected SpecialisedSoldierImpl(
            int id,
            String firstName,
            String lastName,
            double salary,
            String corps) {
        super(id, firstName, lastName, salary);
        this.setCorps(corps);
    }

    @Override
    public String getCorps() {
        return this.corps;
    }

    @Override
    public String toString() {
        return super.toString() +
                String.format("%nCorps: %s", this.corps);
    }

    private void setCorps(String corps) {
        if (!corps.equals("Airforces") && !corps.equals("Marines")) {
            throw new IllegalArgumentException("The corps must be Airforces or Marines.");
        }

        this.corps = corps;
    }
}