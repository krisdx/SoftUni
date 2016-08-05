package problem8_MilitaryElite.models;

import problem8_MilitaryElite.contracts.Commando;
import problem8_MilitaryElite.contracts.Mission;
import problem8_MilitaryElite.contracts.Repair;

import java.util.Collection;
import java.util.Set;

public class CommandoImpl extends SpecialisedSoldierImpl implements Commando {
    private Set<Mission> missions;

    public CommandoImpl(int id,
                        String firstName,
                        String lastName,
                        double salary,
                        String corps,
                        Set<Mission> missions) {
        super(id, firstName, lastName, salary, corps);
        this.missions = missions;
    }

    @Override
    public Collection<Mission> getMissions() {
        return this.missions;
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder(super.toString());

        output.append(System.lineSeparator())
                .append("Missions: ");
        for (Mission mission : this.missions) {
            output.append(System.lineSeparator());
            output.append("  ").append(mission.toString());
        }

        return output.toString().trim();
    }
}