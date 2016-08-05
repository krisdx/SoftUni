package problem3_DependencyInversion.contracts;

public interface Calculator {

    void changeStrategy(CalculatorStrategy calculatorStrategy);

    long performCalculation(int firstOperand, int secondOperand);
}