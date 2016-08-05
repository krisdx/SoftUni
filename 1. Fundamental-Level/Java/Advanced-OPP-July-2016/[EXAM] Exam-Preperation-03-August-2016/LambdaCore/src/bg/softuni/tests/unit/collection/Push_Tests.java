package bg.softuni.tests.unit.collection;

import bg.softuni.app.collection.LStack;
import bg.softuni.app.collection.LinkedStack;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class Push_Tests {

    private LinkedStack<Integer> elements;

    @Before
    public void init() {
        this.elements = new LStack<>();
    }

    @Test
    public void pushElement_intoEmptyStack_shouldPushCorrectly() {
        // Arrange
        Integer pushedElement = 5;

        // Act
        this.elements.push(pushedElement);

        // Assert
        Assert.assertEquals(1, this.elements.getSize());
        Assert.assertEquals(pushedElement, this.elements.peek());
    }

    @Test
    public void pushManyElements_intoEmptyStack_shouldPushCorrectly() {
        // Arrange
        int elementsCount = 100;

        // Act
        for (int i = 0; i < elementsCount; i++) {
            this.elements.push(i);
        }

        // Assert
        Assert.assertEquals(elementsCount, this.elements.getSize());
        for (int i = elementsCount - 1; i >= 0; i--) {
            Assert.assertEquals(Integer.valueOf(i), this.elements.pop());
        }

        Assert.assertEquals(0, this.elements.getSize());
    }
}