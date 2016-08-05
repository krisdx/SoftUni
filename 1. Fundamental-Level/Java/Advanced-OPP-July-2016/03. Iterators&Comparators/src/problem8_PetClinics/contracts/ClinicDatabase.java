package problem8_PetClinics.contracts;

import problem8_PetClinics.models.Animal;

import java.util.Map;

public interface ClinicDatabase {

    Map<String, Animal> getAnimals();

    Map<String, Clinic> getClinics();

    void addAnimal(String name, int age, String kind);

    void addClinic(String name, int rooms);
}