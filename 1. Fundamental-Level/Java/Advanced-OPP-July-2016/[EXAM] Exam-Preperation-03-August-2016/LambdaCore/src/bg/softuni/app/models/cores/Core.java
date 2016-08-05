package bg.softuni.app.models.cores;

import bg.softuni.app.models.fragments.Fragment;

public interface Core {

    Character getName();

    long getDurability();

    void setDurability(long durability);

    int getFragmentsCount();

    void attachFragment(Fragment fragment);

    Fragment detachFragment();
}