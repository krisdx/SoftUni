package bg.softuni.app.models.fragments;

import bg.softuni.app.utility.Messages;
import bg.softuni.app.utility.enums.FragmentType;

public abstract class AbstractFragment implements Fragment {

    private String name;
    private FragmentType type;
    private long pressureAffection;

    protected AbstractFragment(String name, long pressureAffection) {
        this.setName(name);
        this.setPressureAffection(pressureAffection);
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public FragmentType getType() {
        return this.type;
    }

    @Override
    public long getPressureAffection() {
        return this.pressureAffection;
    }

    protected void setType(FragmentType value) {
        this.type = value;
    }

    protected void setPressureAffection(long pressure) {
        if (pressure < 0) {
            throw new IllegalArgumentException(Messages.NEGATIVE_PRESSURE_AFFECTION);
        }

        this.pressureAffection = pressure;
    }

    private void setName(String value) {
        this.name = value;
    }
}