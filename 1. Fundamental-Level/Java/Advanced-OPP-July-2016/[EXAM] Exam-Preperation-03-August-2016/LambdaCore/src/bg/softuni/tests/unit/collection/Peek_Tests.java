package bg.softuni.tests.unit.collection;

import bg.softuni.app.collection.LStack;
import bg.softuni.app.collection.LinkedStack;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class Peek_Tests {
    private LinkedStack<Integer> elements;

    @Before
    public void init() {
        this.elements = new LStack<>();
    }

    @Test
    public void peekElement_shouldReturnLast() {
        // Arrange
        Integer pushedElement = 5;

        // Act
        this.elements.push(pushedElement);

        // Assert
        Assert.assertEquals(pushedElement, this.elements.peek());
    }

    @Test
    public void pushManyElements_hasToReturnLastElement() {
        // Arrange
        int elementsCount = 100;

        // Act
        for (int i = 1; i <= elementsCount; i++) {
            this.elements.push(i);
        }

        // Assert
        Assert.assertEquals(Integer.valueOf(elementsCount), this.elements.peek());
    }

    @Test(expected = UnsupportedOperationException.class)
    public void peekElement_fromEmptyStack_shouldThrow() {
        // Act & Assert
        this.elements.peek();
    }
}