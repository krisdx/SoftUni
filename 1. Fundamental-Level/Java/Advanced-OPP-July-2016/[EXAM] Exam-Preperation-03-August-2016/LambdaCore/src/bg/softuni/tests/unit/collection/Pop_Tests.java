package bg.softuni.tests.unit.collection;

import bg.softuni.app.collection.LStack;
import bg.softuni.app.collection.LinkedStack;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class Pop_Tests {
    private LinkedStack<Integer> elements;

    @Before
    public void init() {
        this.elements = new LStack<>();
    }

    @Test
    public void popElement_shouldPopCorrectly() {
        // Arrange
        Integer pushedElement = 5;

        // Act
        this.elements.push(pushedElement);

        // Assert
        Assert.assertEquals(pushedElement, this.elements.pop());
    }

    @Test
    public void popElement_ensureToPopLasElement() {
        // Arrange
        int elementsCount = 100;

        // Act
        for (int i = 1; i <= elementsCount; i++) {
            this.elements.push(i);
        }

        // Assert
        Assert.assertEquals(Integer.valueOf(elementsCount), this.elements.pop());
    }

    @Test(expected = UnsupportedOperationException.class)
    public void popElement_fromEmptyStack_shouldThrow() {
        // Act & Assert
        this.elements.pop();
    }
}