package bg.softuni.tests.integration.commands.DetachFragmentCommand_Tests;

import bg.softuni.app.data.DataProvider;
import bg.softuni.app.data.LambdaCoreDatabase;
import bg.softuni.app.models.cores.Core;
import bg.softuni.app.models.cores.ParaCore;
import bg.softuni.app.models.fragments.CoolingFragment;
import bg.softuni.app.models.fragments.Fragment;
import bg.softuni.app.models.fragments.NuclearFragment;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class DetachCommand_Tests {

    private DataProvider database;

    @Before
    public void init() {
        this.database = new LambdaCoreDatabase();
    }

    @Test
    public void detachFragmentToExistingCore_shouldDetach() {

        // Arrange
        Core core = new ParaCore(50);
        Fragment fragment = new NuclearFragment("Test", 10);

        // Act & Assert
        this.database.addCore(core);
        this.database.selectCore(core.getName());

        this.database.attachFragment(fragment);
        Assert.assertEquals(1, this.database.getCurrentCore().getFragmentsCount());

        this.database.detachFragment();
        Assert.assertEquals(0, this.database.getCurrentCore().getFragmentsCount());
    }

    @Test
    public void attachSeveralFragment_shouldDetachLasOne() {

        // Arrange
        Core core = new ParaCore(1000);

        int fragmentPressure = 2;
        String fragmentName = Integer.toString(fragmentPressure);

        // Act & Assert
        this.database.addCore(core);
        this.database.selectCore(core.getName());

        for (int i = 1; i <= fragmentPressure; i++) {
            this.database.attachFragment(
                    new CoolingFragment(Integer.toString(i), i));
        }

        Fragment actualFragment = this.database.detachFragment();
        Assert.assertEquals(fragmentName, actualFragment.getName());
        Assert.assertEquals(fragmentPressure * 3, actualFragment.getPressureAffection());
    }

    @Test(expected = UnsupportedOperationException.class)
    public void detachFragment_withNoSelectedCore_shouldThrow() {
        // Act & Assert
        this.database.detachFragment();
    }
}