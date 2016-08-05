package test.bg.softuni.dataStructures;

import main.bg.softuni.contracts.SimpleOrderedBag;
import main.bg.softuni.dataStructures.SimpleSortedList;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

public class SimpleOrderedBagTests {

    private SimpleOrderedBag<String> elements;

    @Before
    public void setUp() {
        this.elements = new SimpleSortedList<>(String.class);
    }

    @Test
    public void testEmptyConstructor() {
        // Arrange
        this.elements = new SimpleSortedList<>(String.class);

        // Assert
        Assert.assertEquals(16, this.elements.capacity());
        Assert.assertEquals(0, this.elements.getSize());
    }

    @Test
    public void testConstructorWithInitialCapacity() {
        // Arrange
        int expectedCapacity = 20;
        this.elements = new SimpleSortedList<>(String.class, expectedCapacity);

        // Assert
        Assert.assertEquals(expectedCapacity, this.elements.capacity());
        Assert.assertEquals(0, this.elements.getSize());
    }

    @Test
    public void testConstructorWithInitialComparer() {
        // Arrange
        this.elements = new SimpleSortedList<>(
                String.class,
                String.CASE_INSENSITIVE_ORDER);

        // Assert
        Assert.assertEquals(16, this.elements.capacity());
        Assert.assertEquals(0, this.elements.getSize());
    }

    @Test
    public void testConstructorWithAllParameters() {
        // Arrange
        int expectedCapacity = 20;
        this.elements = new SimpleSortedList<>(
                String.class,
                String.CASE_INSENSITIVE_ORDER,
                expectedCapacity);

        // Assert
        Assert.assertEquals(expectedCapacity, this.elements.capacity());
        Assert.assertEquals(0, this.elements.getSize());
    }

    @Test
    public void add_ShouldIncreaseSize() {
        // Act
        this.elements.add("Nasko");

        // Assert
        Assert.assertEquals(1, this.elements.getSize());
    }

    @Test(expected = IllegalArgumentException.class)
    public void addNull_ShouldThrow() {
        // Act
        this.elements.add(null);
    }

    @Test
    public void addUnsortedData_ShouldSort() {
        // Arrange
        String expectedResult = "Balkan Georgi Rosen";

        // Act
        this.elements.add("Rosen");
        this.elements.add("Georgi");
        this.elements.add("Balkan");
        String actualResult = this.elements.joinWith(" ");

        // Assert
        Assert.assertEquals(3, this.elements.getSize());
        Assert.assertEquals(expectedResult, actualResult);
    }

    @Test
    public void testAddingMoreThanInitialCapacity() {
        // Arrange
        int initialCapacity = this.elements.capacity();
        int elementsCount = initialCapacity + 1;

        // Act
        for (int i = 0; i < elementsCount; i++) {
            this.elements.add("Rosen");
        }

        // Assert
        Assert.assertTrue(this.elements.capacity() > initialCapacity);
        Assert.assertEquals(elementsCount, this.elements.getSize());
    }

    @Test
    public void testAddingAll_FromCollection_ShouldIncreaseSize() {
        // Arrange
        List<String> names = new ArrayList<>();

        // Act
        names.add("Test");
        names.add("Test2");

        this.elements.addAll(names);

        // Assert
        Assert.assertEquals(2, this.elements.getSize());
    }

    @Test(expected = IllegalArgumentException.class)
    public void testAddingAll_Null_ShouldThrow() {
        // Act & Assert
        this.elements.addAll(null);
    }

    @Test
    public void testAddAll_WithUnsortedElements_ShouldKeepSorted() {
        // Arrange
        String expectedResult = "a b c cc";
        List<String> strings = new ArrayList<>();

        // Act
        strings.add("cc");
        strings.add("c");
        strings.add("b");
        strings.add("a");

        this.elements.addAll(strings);
        String actualResult = this.elements.joinWith(" ");

        // Assert
        Assert.assertEquals(strings.size(), this.elements.getSize());
        Assert.assertEquals(expectedResult, actualResult);
    }

    @Test
    public void testRemove_ShouldDecreaseSize() {
        // Arrange
        int elementsCount = 10;

        // Act
        for (int i = 1; i <= elementsCount; i++) {
            this.elements.add("a");
        }

        // Assert
        for (int i = 1; i <= elementsCount; i++) {
            this.elements.remove("a");
            Assert.assertEquals(elementsCount - i, this.elements.getSize());
        }
    }

    @Test
    public void testRemove_ValidElement_ShouldRemoveSelectedOne() {
        // Act
        this.elements.add("a");
        this.elements.add("b");

        // Assert
        Assert.assertTrue(this.elements.remove("a"));
        Assert.assertEquals(1, this.elements.getSize());
    }

    @Test(expected = IllegalArgumentException.class)
    public void testRemovingNullThrowsException() {
        // Act & Assert
        this.elements.remove(null);
    }

    @Test(expected = IllegalArgumentException.class)
    public void testJoinWithNull_ShouldThrow() {
        // Act
        this.elements.add("a");
        this.elements.add("b");
        this.elements.add("c");

        // Act & Assert
        this.elements.joinWith(null);
    }

    @Test()
    public void testJoin_ShouldWorkCorrect() {
        // Arrange
        String expectedResult = "a b c";

        // Act
        this.elements.add("a");
        this.elements.add("b");
        this.elements.add("c");
        String actualResult = this.elements.joinWith(" ");

        // Act & Assert
        Assert.assertEquals(expectedResult, actualResult);
    }
}