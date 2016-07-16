package problem5_PizzaCalories.models;

public class Topping {
    private String type;
    private double weight;

    public Topping(String type, double weight) {
        this.setType(type);
        this.setWeight(weight, type);
    }

    public double calculateCalories(){
        return 2 * this.getToppingModifier(this.type) * this.weight;
    }

    private void setType(String type) {
        //meat, veggies, cheese or a sauce
        if (!type.equalsIgnoreCase("meat") &&
                !type.equalsIgnoreCase("veggies") &&
                !type.equalsIgnoreCase("cheese") &&
                !type.equalsIgnoreCase("sauce")){
            throw new IllegalArgumentException(
                    String.format("Cannot place %s on top of your pizza.", type));
        }

        this.type = type;
    }

    private void setWeight(double weight, String type) {
        if (weight < 1 || weight > 50){
            throw new IllegalArgumentException(
                    String.format("%s weight should be in the range [1..50].", this.type));
        }
        this.weight = weight;
    }

    private double getToppingModifier(String type){
        final double MEAT_MODIFIER = 1.2;
        final double VEGGIES_MODIFIER = 0.8;
        final double CHEESE_MODIFIER = 1.1;
        final double SAUCE_MODIFIER = 0.9;

        switch (type.toLowerCase()){
            case "meat":
                return MEAT_MODIFIER;

            case "veggies":
                return VEGGIES_MODIFIER;

            case "cheese":
                return CHEESE_MODIFIER;

            case "sauce":
                return SAUCE_MODIFIER;

            default:
                return 1;
        }
    }
}
