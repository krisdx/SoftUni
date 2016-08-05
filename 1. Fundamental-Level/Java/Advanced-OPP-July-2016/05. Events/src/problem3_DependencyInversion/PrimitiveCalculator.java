package problem3_DependencyInversion;

import problem3_DependencyInversion.calculatorStrategies.AdditionCalculatorStrategy;
import problem3_DependencyInversion.contracts.Calculator;
import problem3_DependencyInversion.contracts.CalculatorStrategy;

public class PrimitiveCalculator implements Calculator {

    private CalculatorStrategy calculatorStrategy;

    public PrimitiveCalculator() {
        this.setCalculatorStrategy(new AdditionCalculatorStrategy());
    }

    public PrimitiveCalculator(CalculatorStrategy calculatorStrategy) {
        this.setCalculatorStrategy(calculatorStrategy);
    }

    @Override
    public void changeStrategy(CalculatorStrategy calculatorStrategy) {
        this.setCalculatorStrategy(calculatorStrategy);
    }

    @Override
    public long performCalculation(int firstOperand, int secondOperand) {
        return this.calculatorStrategy.calculate(firstOperand, secondOperand);
    }

    private void setCalculatorStrategy(CalculatorStrategy calculatorStrategy) {
        if (calculatorStrategy != null) {
            this.calculatorStrategy = calculatorStrategy;
        }
    }
}