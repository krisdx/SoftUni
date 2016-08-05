package problem3_DependencyInversion.contracts;

public interface CalculatorStrategy {
    long calculate(int firstOperand, int secondOperand);
}