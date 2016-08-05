package problem8_MilitaryElite.models;

import problem8_MilitaryElite.contracts.Repair;

public class RepairImpl implements Repair {
    private String partName;
    private int workHours;

    public RepairImpl(String partName, int workHours) {
        this.partName = partName;
        this.workHours = workHours;
    }

    @Override
    public String getPartName() {
        return this.partName;
    }

    @Override
    public int getHoursWorked() {
        return this.workHours;
    }

    @Override
    public String toString() {
        return String.format("Part Name: %s Hours Worked: %d",
                this.partName, this.workHours);
    }
}