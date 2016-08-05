package problem8_PetClinics.data;

import problem8_PetClinics.models.Animal;
import problem8_PetClinics.contracts.Clinic;
import problem8_PetClinics.contracts.ClinicDatabase;
import problem8_PetClinics.contracts.factories.ClinicFactory;
import problem8_PetClinics.contracts.factories.AnimalFactory;

import java.util.*;

public class ClinicDatabaseImpl implements ClinicDatabase {

    private ClinicFactory clinicFactory;
    private AnimalFactory petFactory;

    private Map<String, Animal> animals;
    private Map<String, Clinic> clinics;

    public ClinicDatabaseImpl(ClinicFactory clinicFactory, AnimalFactory petFactory) {
        this.clinicFactory = clinicFactory;
        this.petFactory = petFactory;
        this.animals = new LinkedHashMap<>();
        this.clinics = new LinkedHashMap<>();
    }

    @Override
    public Map<String, Animal> getAnimals() {
        return this.animals;
    }

    @Override
    public Map<String, Clinic> getClinics() {
        return this.clinics;
    }

    @Override
    public void addAnimal(String name, int age, String kind) {
        Animal pet = this.petFactory.createPet(name, age, kind);
        this.animals.put(name, pet);
    }

    @Override
    public void addClinic(String name, int rooms) {
        Clinic clinic = this.clinicFactory.createClinic(name, rooms);
        this.clinics.put(name, clinic);
    }
}