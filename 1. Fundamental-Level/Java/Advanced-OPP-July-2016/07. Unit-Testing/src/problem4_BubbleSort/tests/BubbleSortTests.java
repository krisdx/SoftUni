package problem4_BubbleSort.tests;

import org.junit.Assert;
import org.junit.Test;
import problem4_BubbleSort.BubbleSortAlgorithm;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class BubbleSortTests {

    private List<Integer> elements;

    @Test
    public void sortElements_ShouldSortCorrectly() {
        // Arrange
        this.elements = new ArrayList<>();
        int elementsCount = 10;

        // Act
        for (int i = elementsCount - 1; i >= 0; i--) {
            this.elements.add(i);
        }

        BubbleSortAlgorithm.sort(this.elements);

        // Assert
        for (Integer i = 0; i < elementsCount; i++) {
            Assert.assertEquals(i, this.elements.get(i));
        }
        Assert.assertTrue(this.elements.size() == elementsCount);
    }

    @Test
    public void randomElementsInCollection_ShouldSortCorrectly() {
        // Arrange
        Random randomGenerator = new Random();
        this.elements = new ArrayList<>();
        int elementsCount = 10;

        // Act
        for (int i = elementsCount - 1; i >= 0; i--) {
            this.elements.add(randomGenerator.nextInt(100));
        }

        BubbleSortAlgorithm.sort(this.elements);

        // Assert
        for (Integer i = 0; i < elementsCount - 1; i++) {
            Integer currentElement = this.elements.get(i);
            Integer nextElement = this.elements.get(i + 1);
            Assert.assertTrue(currentElement <= nextElement);
        }

        Assert.assertTrue(this.elements.size() == elementsCount);
    }

    @Test
    public void sortOneElement_ShouldDoNothing() {
        // Arrange
        Integer expectedElement = 1;
        this.elements = new ArrayList<>();

        // Act
        this.elements.add(expectedElement);
        BubbleSortAlgorithm.sort(this.elements);

        // Assert
        Assert.assertEquals(expectedElement, this.elements.get(0));
        Assert.assertTrue(this.elements.size() == 1);
    }

    @Test
    public void sortEmptyCollection_ShouldDoNothing() {
        // Arrange
        this.elements = new ArrayList<>();

        // Act
        BubbleSortAlgorithm.sort(this.elements);

        // Assert
        Assert.assertTrue(this.elements.isEmpty());
    }
}