package problem8_MilitaryElite.contracts;

import java.util.Collection;

public interface Commando extends SpecialisedSoldier {
    Collection<Mission> getMissions();
}