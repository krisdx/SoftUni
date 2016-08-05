package problem8_PetClinics.contracts.factories;

import problem8_PetClinics.models.Animal;

public interface AnimalFactory {
    Animal createPet(String name, int age, String kind);
}