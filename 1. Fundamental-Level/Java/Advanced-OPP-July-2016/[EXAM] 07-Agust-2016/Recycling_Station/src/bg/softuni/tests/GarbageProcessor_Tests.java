package bg.softuni.tests;

import bg.softuni.app.framework.contracts.GarbageProcessor;
import bg.softuni.app.framework.contracts.ProcessingData;
import bg.softuni.app.framework.contracts.StrategyHolder;
import bg.softuni.app.framework.contracts.Waste;
import bg.softuni.app.framework.processingData.ProcessingDataImpl;
import bg.softuni.app.framework.strategyHolder.StrategyHolderImpl;
import bg.softuni.app.models.garbage.BurnableGarbage;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.mockito.Mockito;

public class GarbageProcessor_Tests {

    private GarbageProcessor mockGarbageProcessor;

    @Before
    public void init() {
        this.mockGarbageProcessor = Mockito.mock(GarbageProcessor.class);
    }

    @Test
    public void test_getStrategyHolder_shouldReturnCorrectStrategyHolder() {
        // Arrange
        StrategyHolder expected = new StrategyHolderImpl();
        Mockito.when(this.mockGarbageProcessor.getStrategyHolder())
                .thenReturn(expected);

        // Act
        StrategyHolder actual = this.mockGarbageProcessor.getStrategyHolder();

        // Assert
        Assert.assertEquals(expected, actual);
    }

    @Test
    public void test_processWaste_shouldReturnCorrectData() {
        // Arrange
        ProcessingData expected = new ProcessingDataImpl(20, 20);
        Mockito.when(this.mockGarbageProcessor.processWaste(Mockito.any(Waste.class)))
                .thenReturn(expected);

        // Act
        ProcessingData actual = this.mockGarbageProcessor.processWaste(
                new BurnableGarbage("Test", 1.0, 1.0));

        // Assert
        Assert.assertEquals(expected, actual);
    }
}