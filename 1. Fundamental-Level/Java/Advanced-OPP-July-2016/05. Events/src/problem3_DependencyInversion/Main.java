package problem3_DependencyInversion;

import problem3_DependencyInversion.calculatorStrategies.*;
import problem3_DependencyInversion.contracts.Calculator;
import problem3_DependencyInversion.contracts.CalculatorStrategy;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) throws IOException {

        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        Calculator calculator = new PrimitiveCalculator();
        while (true) {
            String line = reader.readLine();
            if (line.equalsIgnoreCase("end")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            if (lineArgs[0].equalsIgnoreCase("mode")) {
                CalculatorStrategy calculatorStrategy = getCalculatorStrategy(lineArgs[1]);
                calculator.changeStrategy(calculatorStrategy);
            } else {
                int firstOperand = Integer.valueOf(lineArgs[0]);
                int secondOperand = Integer.valueOf(lineArgs[1]);

                long result = calculator.performCalculation(firstOperand, secondOperand);
                System.out.println(result);
            }
        }
    }

    private static CalculatorStrategy getCalculatorStrategy(String operator) {
        switch (operator) {
            case "+":
                return new AdditionCalculatorStrategy();
            case "-":
                return new SubtractionCalculatorStrategy();
            case "*":
                return new MultiplyCalculatorStrategy();
            case "/":
                return new DivisionCalculatorStrategy();
            default:
                throw new IllegalArgumentException("Unknown arithmetic operator");
        }
    }
}