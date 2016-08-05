package problem1_Database.tests;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import problem1_Database.Database;
import problem1_Database.IntegerDatabase;

import javax.naming.OperationNotSupportedException;

public class Add_Tests {

    private Database elements;

    @Before
    public void initialize() {
        this.elements = new IntegerDatabase();
    }

    @Test
    public void addOneElement_ShouldAdd() throws OperationNotSupportedException {
        // Arrange
        Integer actualElement = 5;

        // Act
        this.elements.add(actualElement);

        // Assert
        Assert.assertEquals(this.elements.fetch()[0], actualElement);
        Assert.assertTrue(this.elements.fetch().length == 1);
    }

    @Test
    public void addManyElements_ShouldAddAll() throws OperationNotSupportedException {
        // Arrange
        int elementsCount = 100;

        // Act
        for (int element = 0; element < elementsCount; element++) {
            this.elements.add(element);
        }

        // Assert
        for (int i = 0; i < elementsCount; i++) {
            Integer actualElement = i;
            Assert.assertEquals(this.elements.fetch()[i], actualElement);
        }

        Assert.assertTrue(this.elements.fetch().length == elementsCount);
    }

    @Test(expected = OperationNotSupportedException.class)
    public void addNullElement_ShouldThrow() throws OperationNotSupportedException {
        // Act
        this.elements.add(null);
    }
}