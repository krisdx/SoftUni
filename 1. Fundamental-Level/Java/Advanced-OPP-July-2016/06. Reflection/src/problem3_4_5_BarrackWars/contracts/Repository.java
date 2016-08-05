package problem3_4_5_BarrackWars.contracts;

import java.util.Map;

public interface Repository {

    Map<String, Integer> getUnitsAmount();

    void addUnit(Unit unit);

    String getStatistics();

    void removeUnit(String unitType);
}