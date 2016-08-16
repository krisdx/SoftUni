package bg.softuni.app.models.garbage;

import bg.softuni.app.framework.contracts.Waste;
import bg.softuni.app.utility.Messages;

public abstract class AbstractGarbage implements Waste {

    private String name;
    private double weight;
    private double volumePerKg;

    protected AbstractGarbage(String name, double weight, double volumePerKg) {
        this.setName(name);
        this.setWeight(weight);
        this.setVolumePerKg(volumePerKg);
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public double getWeight() {
        return this.weight;
    }

    @Override
    public double getVolumePerKg() {
        return this.volumePerKg;
    }

    private void setName(String name) {
        if (name == null || name.isEmpty()) {
            throw new IllegalArgumentException(Messages.NULL_NAME);
        }

        this.name = name;
    }

    private void setWeight(double weight) {
        this.validateArgument(weight, "weight");
        this.weight = weight;
    }

    private void setVolumePerKg(double volumePerKg) {
        this.validateArgument(weight, "volumePerKg");
        this.volumePerKg = volumePerKg;
    }

    private void validateArgument(double argument, String type) {
        if (argument < 0.0) {
            throw new IllegalArgumentException(
                    String.format(Messages.NEGATIVE_ARGUMENT, type));
        }
    }
}