package problem3_ListIterator.tests;

import org.junit.Assert;
import org.junit.Test;
import problem3_ListIterator.CustomIterator;
import problem3_ListIterator.CustomListIterator;

public class Move_Tests {

    private CustomIterator<Integer> customIterator;

    @Test
    public void move_ShouldMove() {
        // Arrange
        this.customIterator = new CustomListIterator<>(1, 2, 3);

        // Act
        boolean hasMoved = this.customIterator.move();

        // Assert
        Assert.assertTrue(hasMoved);
    }

    @Test
    public void moveOnEmptyCollection_ShouldNotMove() {
        // Arrange
        this.customIterator = new CustomListIterator<>();

        // Act
        boolean hasMoved = this.customIterator.move();

        // Assert
        Assert.assertFalse(hasMoved);
    }
}