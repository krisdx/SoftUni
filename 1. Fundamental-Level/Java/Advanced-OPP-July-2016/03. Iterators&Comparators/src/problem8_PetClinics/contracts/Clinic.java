package problem8_PetClinics.contracts;

import problem8_PetClinics.models.Animal;

import java.util.*;

public interface Clinic {

    boolean addAnimal(Animal animal);

    boolean releaseAnimal();

    Map<Integer, Animal> getRooms();

    boolean hasEmptyRooms();
}