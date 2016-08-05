package bg.softuni.app.models.fragments;

import bg.softuni.app.models.cores.Core;
import bg.softuni.app.utility.enums.FragmentType;

public interface Fragment {

    String getName();

    FragmentType getType();

    long getPressureAffection();

    void applyEffect(Core core);

    void removeEffect(Core core);
}