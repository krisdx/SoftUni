package bg.softuni.tests.integration.commands.SelectCommand_Tests;

import bg.softuni.app.data.DataProvider;
import bg.softuni.app.data.LambdaCoreDatabase;
import bg.softuni.app.models.cores.Core;
import bg.softuni.app.models.cores.ParaCore;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class SelectCommand_Tests {

    private DataProvider database;

    @Before
    public void init(){
        this.database = new LambdaCoreDatabase();
    }

    @Test
    public void selectCore_shouldSelectCorrectly() {
        // Arrange
        Core core = new ParaCore(50);

        // Act
        this.database.addCore(core);
        this.database.selectCore(core.getName());

        // Assert
        Assert.assertEquals(core, this.database.getCurrentCore());
    }

    @Test(expected = UnsupportedOperationException.class)
    public void selectNonExistentCore_shouldThrow() {
        // Act & Assert
        this.database.selectCore('A');
    }
}