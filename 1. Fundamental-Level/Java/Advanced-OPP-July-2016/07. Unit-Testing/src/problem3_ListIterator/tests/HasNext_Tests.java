package problem3_ListIterator.tests;

import org.junit.Assert;
import org.junit.Test;
import problem3_ListIterator.CustomIterator;
import problem3_ListIterator.CustomListIterator;

import java.util.ArrayList;
import java.util.List;

public class HasNext_Tests {

    private CustomIterator<Integer> customIterator;

    @Test
    public void hasNextWithManyElements() {
        // Arrange
        int elementsCount = 100;
        List<Integer> collection = new ArrayList<>();
        for (int i = 0; i < elementsCount; i++) {
            collection.add(i);
        }

        this.customIterator = new CustomListIterator<>(collection);

        // Act & Assert
        for (int i = 0; i < elementsCount - 1; i++) {
            boolean hasNext = this.customIterator.hasNext();
            Assert.assertTrue(hasNext);
            this.customIterator.move();
        }

        Assert.assertFalse(this.customIterator.hasNext());
    }

    @Test
    public void hasNextWithOneElement() {
        // Arrange
        this.customIterator = new CustomListIterator<>(1);

        // Act
        boolean hasNext = this.customIterator.hasNext();

        // Assert
        Assert.assertFalse(hasNext);
    }


    @Test
    public void hasNextOnEmptyCollection_ShouldNotHaveNext() {
        // Arrange
        this.customIterator = new CustomListIterator<>();

        // Act
        boolean hasNext = this.customIterator.hasNext();

        // Assert
        Assert.assertFalse(hasNext);
    }
}