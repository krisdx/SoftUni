package problem3_4_5_BarrackWars.data;

import problem3_4_5_BarrackWars.contracts.Repository;
import problem3_4_5_BarrackWars.contracts.Unit;

import java.util.Map;
import java.util.TreeMap;

public class UnitRepository implements Repository {

    private Map<String, Integer> amountOfUnits;

    public UnitRepository() {
        this.amountOfUnits = new TreeMap<>();
    }

    @Override
    public Map<String, Integer> getUnitsAmount() {
        return this.amountOfUnits;
    }

    @Override
    public void addUnit(Unit unit) {
        String unitType = unit.getClass().getSimpleName();
        if (!this.amountOfUnits.containsKey(unitType)) {
            this.amountOfUnits.put(unitType, 0);
        }

        int newAmount = this.amountOfUnits.get(unitType) + 1;
        this.amountOfUnits.put(unitType, newAmount);
    }

    @Override
    public String getStatistics() {
        StringBuilder statBuilder = new StringBuilder();
        for (Map.Entry<String, Integer> entry : amountOfUnits.entrySet()) {
            String formatedEntry =
                    String.format("%s -> %d%n", entry.getKey(), entry.getValue());
            statBuilder.append(formatedEntry);
        }

        statBuilder.setLength(statBuilder.length() - 1);
        return statBuilder.toString().trim();
    }

    @Override
    public void removeUnit(String unitType) {
        int newAmount = this.amountOfUnits.get(unitType) - 1;
        this.amountOfUnits.put(unitType, newAmount);
    }
}