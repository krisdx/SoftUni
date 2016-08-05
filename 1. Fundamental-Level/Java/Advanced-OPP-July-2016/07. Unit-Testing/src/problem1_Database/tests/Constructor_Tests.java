package problem1_Database.tests;

import problem1_Database.Database;

import org.junit.Assert;
import org.junit.Test;
import problem1_Database.IntegerDatabase;

import javax.naming.OperationNotSupportedException;


public class Constructor_Tests {

    private Database elements;

    @Test
    public void oneElement_ShouldAddCorrectly() {
        // Arrange
        Integer actualElement = 5;
        this.elements = new IntegerDatabase(actualElement);

        // Assert
        Assert.assertEquals(this.elements.fetch()[0], actualElement);
        Assert.assertTrue(this.elements.fetch().length == 1);
    }

    @Test
    public void addManyElements_ShouldAddAll() {
        // Arrange
        int elementsCount = 100;
        Integer[] elementsToAdd = new Integer[elementsCount];
        for (int i = 0; i < elementsCount; i++) {
            elementsToAdd[i] = i;
        }

        this.elements = new IntegerDatabase(elementsToAdd);

        // Assert
        Assert.assertTrue(this.elements.fetch().length == elementsCount);
    }

    @Test
    public void emptyVarargs() {
        // Arrange
        this.elements = new IntegerDatabase();

        // Assert
        Assert.assertTrue(this.elements.fetch().length == 0);
    }
}
