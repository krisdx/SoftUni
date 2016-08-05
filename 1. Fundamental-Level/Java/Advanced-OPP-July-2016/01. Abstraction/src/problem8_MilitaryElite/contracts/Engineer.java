package problem8_MilitaryElite.contracts;

import java.util.Collection;

public interface Engineer extends SpecialisedSoldier {
    Collection<Repair> getRepairs();
}