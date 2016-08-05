package bg.softuni.tests.unit.collection;

import bg.softuni.app.collection.LStack;
import bg.softuni.app.collection.LinkedStack;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class IsEmpty_Tests {
    private LinkedStack<Integer> elements;

    @Before
    public void init() {
        this.elements = new LStack<>();
    }

    @Test
    public void emptyStack_ShouldBeEmpty() {
        Assert.assertTrue(this.elements.isEmpty());
    }

    @Test
    public void pushManyElement_shouldNotBeEmpty() {
        // Arrange
        int elementsCount = 100;

        // Act
        for (int i = 1; i <= elementsCount; i++) {
            this.elements.push(i);
        }

        // Assert
        Assert.assertFalse(this.elements.isEmpty());
    }
}