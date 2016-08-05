package problem8_PetClinics.core.factories;

import problem8_PetClinics.models.Animal;
import problem8_PetClinics.models.Pet;
import problem8_PetClinics.contracts.factories.AnimalFactory;

public class PetFactory implements AnimalFactory {

    @Override
    public Animal createPet(String name, int age, String kind) {
        return new Pet(name, age, kind);
    }
}