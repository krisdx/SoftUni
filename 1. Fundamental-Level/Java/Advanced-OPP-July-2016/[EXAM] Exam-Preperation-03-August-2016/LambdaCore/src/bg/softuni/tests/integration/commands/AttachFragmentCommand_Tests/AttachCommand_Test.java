package bg.softuni.tests.integration.commands.AttachFragmentCommand_Tests;

import bg.softuni.app.data.DataProvider;
import bg.softuni.app.data.LambdaCoreDatabase;
import bg.softuni.app.models.cores.Core;
import bg.softuni.app.models.cores.ParaCore;
import bg.softuni.app.models.fragments.Fragment;
import bg.softuni.app.models.fragments.NuclearFragment;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class AttachCommand_Test {

    private DataProvider database;

    @Before
    public void init() {
        this.database = new LambdaCoreDatabase();
    }

    @Test
    public void attachFragmentToExistingCore_shouldAttach() {
        // Arrange
        Core core = new ParaCore(50);
        Fragment fragment = new NuclearFragment("Test", 10);

        // Act
        this.database.addCore(core);
        this.database.selectCore(core.getName());

        this.database.attachFragment(fragment);

        // Assert
        Assert.assertEquals(1, this.database.getCurrentCore().getFragmentsCount());
    }

    @Test(expected = IllegalArgumentException.class)
    public void attachFragment_withNegativePressure_shouldThrow() {
        Fragment fragment = new NuclearFragment("Test", -10);
    }

    @Test(expected = UnsupportedOperationException.class)
    public void attachFragment_withNoSelectedCore_shouldThrow() {
        // Arrange
        Fragment fragment = new NuclearFragment("Test", 10);

        // Act & Assert
        this.database.attachFragment(fragment);
    }
}