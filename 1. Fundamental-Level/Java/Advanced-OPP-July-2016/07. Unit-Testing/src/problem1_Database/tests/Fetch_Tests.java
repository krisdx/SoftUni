package problem1_Database.tests;

import org.junit.Assert;
import org.junit.Test;
import problem1_Database.Database;
import problem1_Database.IntegerDatabase;

public class Fetch_Tests {

    private Database elements;

    @Test
    public void fetchOneElement_ShouldFetchCorrectly(){

        // Arrange
        Integer actualElement = 5;
        this.elements = new IntegerDatabase(actualElement);

        // Assert
        Assert.assertEquals(this.elements.fetch()[0], actualElement);
        Assert.assertTrue(this.elements.fetch().length == 1);
    }

    @Test
    public void fetchEmptyElements_ShouldRemoveEmptyArray(){

        // Arrange
        this.elements = new IntegerDatabase();

        // Assert
        Assert.assertTrue(this.elements.fetch().length == 0);
    }
}