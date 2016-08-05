package problem10_11_12_13_InfernoInfinity.core.factories;

import problem10_11_12_13_InfernoInfinity.contracts.factories.GemFactory;
import problem10_11_12_13_InfernoInfinity.utilities.ExceptionMessages;
import problem10_11_12_13_InfernoInfinity.models.gems.Amethyst;
import problem10_11_12_13_InfernoInfinity.models.gems.Emerald;
import problem10_11_12_13_InfernoInfinity.models.gems.AbstractGem;
import problem10_11_12_13_InfernoInfinity.models.gems.Ruby;

public class GemFactoryImpl implements GemFactory {

    @Override
    public AbstractGem createGem(String gemType) {
        switch (gemType.toLowerCase()) {
            case "ruby":
                return new Ruby();
            case "emerald":
                return new Emerald();
            case "amethyst":
                return new Amethyst();
            default:
                throw new IllegalArgumentException(
                        ExceptionMessages.UNKNOWN_GEM_TYPE);
        }
    }
}