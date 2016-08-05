package problem3_DependencyInversion.calculatorStrategies;

import problem3_DependencyInversion.contracts.CalculatorStrategy;

public class SubtractionCalculatorStrategy implements CalculatorStrategy {

    @Override
    public long calculate(int firstOperand, int secondOperand) {
        return (long) firstOperand - secondOperand;
    }
}