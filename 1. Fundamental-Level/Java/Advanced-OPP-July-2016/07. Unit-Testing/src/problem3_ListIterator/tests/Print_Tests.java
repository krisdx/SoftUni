package problem3_ListIterator.tests;

import org.junit.Assert;
import org.junit.Test;
import problem3_ListIterator.CustomIterator;
import problem3_ListIterator.CustomListIterator;

import javax.naming.OperationNotSupportedException;
import java.util.ArrayList;
import java.util.List;

public class Print_Tests {

    private CustomIterator<Integer> customIterator;

    @Test
    public void printOneElement()
            throws OperationNotSupportedException {

        // Arrange
        Integer expectedElement = 1;
        this.customIterator = new CustomListIterator<>(expectedElement);

        // Act
        Integer actualElement = this.customIterator.print();

        // Assert
        Assert.assertEquals(expectedElement, actualElement);
    }

    @Test
    public void printManyElements()
            throws OperationNotSupportedException {

        // Arrange
        int elementsCount = 100;
        List<Integer> collection = new ArrayList<>();
        for (int i = 0; i < elementsCount; i++) {
            collection.add(i);
        }

        this.customIterator = new CustomListIterator<>(collection);

        // Act & Assert
        for (Integer expected = 0; expected < elementsCount; expected++) {
            Integer actualElement = this.customIterator.print();
            Assert.assertEquals(actualElement, expected);
            this.customIterator.move();
        }
    }

    @Test(expected = OperationNotSupportedException.class)
    public void print_OnEmptyCollection_ShouldThrow()
            throws OperationNotSupportedException {

        // Arrange
        this.customIterator = new CustomListIterator<>();

        // Act & Assert
        this.customIterator.print();
    }
}