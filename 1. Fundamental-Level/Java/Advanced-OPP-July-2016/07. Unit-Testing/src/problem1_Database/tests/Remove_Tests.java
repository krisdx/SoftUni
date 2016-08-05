package problem1_Database.tests;

import org.junit.Assert;
import org.junit.Test;
import problem1_Database.Database;
import problem1_Database.IntegerDatabase;

import javax.naming.OperationNotSupportedException;

public class Remove_Tests {

    private Database elements;

    @Test
    public void removeOneElement_ShouldRemoveCorrectly()
            throws OperationNotSupportedException {

        // Arrange
        Integer actualElement = 5;
        this.elements = new IntegerDatabase(actualElement);

        // Act
        Integer expectedElement = this.elements.remove();

        // Assert
        Assert.assertEquals(expectedElement, actualElement);
        Assert.assertTrue(this.elements.fetch().length == 0);
    }

    @Test
    public void removeManyElements_ShouldRemoveAllCorrectly()
            throws OperationNotSupportedException {

        // Arrange
        int elementsCount = 100;
        Integer[] a = new Integer[elementsCount];
        for (int i = 0; i < elementsCount; i++) {
            a[i] = i;
        }

        this.elements = new IntegerDatabase(a);

        // Act & Assert
        for (int i = elementsCount - 1; i >= 0; i--) {
            Integer actualElement = this.elements.fetch()[i];
            Integer expectedElement = this.elements.remove();
            Assert.assertEquals(expectedElement, actualElement);
        }

        Assert.assertTrue(this.elements.fetch().length == 0);
    }

    @Test(expected = OperationNotSupportedException.class)
    public void addNullElement_ShouldThrow() throws OperationNotSupportedException {
        // Arrange
        this.elements = new IntegerDatabase();

        // Act
        this.elements.remove();
    }
}