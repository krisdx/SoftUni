package bg.softuni.tests;

import bg.softuni.app.framework.annotations.RecyclableGarbageAnnotation;
import bg.softuni.app.framework.contracts.GarbageDisposalStrategy;
import bg.softuni.app.framework.contracts.StrategyHolder;
import bg.softuni.app.framework.strategy.BurnableGarbageStrategy;
import bg.softuni.app.framework.strategyHolder.StrategyHolderImpl;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class StrategyHolder_Tests {

    private StrategyHolder strategyHolder;

    @Before
    public void init() {
        this.strategyHolder = new StrategyHolderImpl();
    }

    @Test
    public void test_addStrategy_shouldAdd() {
        // Arrange
        GarbageDisposalStrategy expected = new BurnableGarbageStrategy();

        // Act & Assert
        Assert.assertTrue(
                this.strategyHolder.addStrategy(RecyclableGarbageAnnotation.class, expected));
        Assert.assertEquals(1, this.strategyHolder.getDisposalStrategies().size());
    }

    @Test
    public void test_addExistingStrategy_shouldNotAdd() {
        // Arrange
        GarbageDisposalStrategy expected = new BurnableGarbageStrategy();

        // Act & Assert
        this.strategyHolder.addStrategy(RecyclableGarbageAnnotation.class, expected);
        Assert.assertFalse(
                this.strategyHolder.addStrategy(RecyclableGarbageAnnotation.class, expected));
    }

    @Test
    public void test_removeStrategy_shouldRemove() {
        // Arrange
        Class annotationClass = RecyclableGarbageAnnotation.class;
        GarbageDisposalStrategy expected = new BurnableGarbageStrategy();

        // Act & Assert
        this.strategyHolder.addStrategy(annotationClass, expected);
        Assert.assertEquals(1, this.strategyHolder.getDisposalStrategies().size());

        Assert.assertTrue(this.strategyHolder.removeStrategy(annotationClass));
        Assert.assertEquals(0, this.strategyHolder.getDisposalStrategies().size());
    }

    @Test
    public void test_removeNonExistingStrategy_shouldDoNothing() {
        // Act & Assert
        Assert.assertFalse(this.strategyHolder.removeStrategy(RecyclableGarbageAnnotation.class));
    }
}