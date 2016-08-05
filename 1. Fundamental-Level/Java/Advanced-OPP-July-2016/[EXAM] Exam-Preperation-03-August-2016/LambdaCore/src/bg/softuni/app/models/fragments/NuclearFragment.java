package bg.softuni.app.models.fragments;

import bg.softuni.app.models.cores.Core;
import bg.softuni.app.utility.enums.FragmentType;

public class NuclearFragment extends AbstractFragment implements Fragment {

    public NuclearFragment(String name, long pressureAffection) {
        super(name, pressureAffection);
        this.setType(FragmentType.Nuclear);
    }

    @Override
    protected void setPressureAffection(long pressure) {
        super.setPressureAffection(pressure * 2);
    }

    @Override
    public void applyEffect(Core core) {
        core.setDurability(core.getDurability() - this.getPressureAffection());
    }

    @Override
    public void removeEffect(Core core) {
        core.setDurability(core.getDurability() + this.getPressureAffection());
    }
}