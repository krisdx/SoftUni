package problem10_11_12_13_InfernoInfinity.contracts.factories;

import problem10_11_12_13_InfernoInfinity.contracts.models.Gem;

public interface GemFactory {
    Gem createGem(String gemType);
}