import java.io.IOException;

public class Problem6_PlanckConstant {
    public static void main(String[] args) throws IOException {
        System.out.println(Calculation.calculate());
    }
}

class Calculation {
    public static double planck = 6.62606896e-34;
    public static double Pi = 3.14159;

    public static double calculate() {
        return planck / (2 * Pi);
    }
}