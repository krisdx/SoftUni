package problem5_PizzaCalories.models;

public class Dough {

    private String flourType;
    private String bakingTechnique;
    private double weight;

    public Dough(String flourType, String bakingTechnique, double weight) {
        this.setFlourType(flourType);
        this.setBakingTechnique(bakingTechnique);
        this.setWeight(weight);
    }

    public double calculateCalories(){
        return 2 * this.getModifier(this.flourType) * this.getModifier(this.bakingTechnique) * this.weight;
    }

    private void setWeight(double weight) {
        if (weight < 1 || weight > 200){
            throw new IllegalArgumentException("Dough weight should be in the range [1..200].");
        }
        this.weight = weight;
    }

    private void setFlourType(String flourType) {
        //white or wholegrain
        if (!flourType.equalsIgnoreCase("white") && !flourType.equalsIgnoreCase("wholegrain")){
            throw new IllegalArgumentException("Invalid type of dough.");
        }

        this.flourType = flourType;
    }

    private void setBakingTechnique(String bakingTechnique) {
        //crispy, chewy or homemade
        if (!bakingTechnique.equalsIgnoreCase("crispy") &&
                !bakingTechnique.equalsIgnoreCase("chewy") &&
                !bakingTechnique.equalsIgnoreCase("homemade")){
            throw new IllegalArgumentException("Invalid type of dough.");
        }

        this.bakingTechnique =  bakingTechnique;
    }

    private double getModifier(String type){
        final double WHITE_FLOUR_MODIFIER = 1.5;
        final double WHOLEGRAIN_FLOUR_MODIFIER = 1.0;
        final double CRISPY_MODIFIER = 0.9;
        final double CHEWY_MODIFIER = 1.1;
        final double HOMEMADE_MODIFIER = 1.0;

        switch (type.toLowerCase()){
            case "white":
                return WHITE_FLOUR_MODIFIER;

            case "wholegrain":
                return WHOLEGRAIN_FLOUR_MODIFIER;

            case "crispy":
                return CRISPY_MODIFIER;

            case "chewy":
                return CHEWY_MODIFIER;

            case "homemade":
                return HOMEMADE_MODIFIER;

            default:
                return 1;
        }
    }
}
