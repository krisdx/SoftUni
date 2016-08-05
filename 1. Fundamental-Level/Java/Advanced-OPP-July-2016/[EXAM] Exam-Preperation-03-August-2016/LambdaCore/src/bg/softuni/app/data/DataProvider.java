package bg.softuni.app.data;

import bg.softuni.app.models.cores.Core;
import bg.softuni.app.models.fragments.Fragment;

public interface DataProvider {

    Core getCurrentCore();

    void addCore(Core core);

    void removeCore (Character coreName);

    void selectCore(Character coreName);

    void attachFragment(Fragment fragment);

    Fragment detachFragment();

    String status();
}