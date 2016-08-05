package problem8_PetClinics.core.factories;

import problem8_PetClinics.models.AnimalClinic;
import problem8_PetClinics.contracts.Clinic;
import problem8_PetClinics.contracts.factories.ClinicFactory;

public class ClinicFactoryImpl implements ClinicFactory {

    @Override
    public Clinic createClinic(String name, int rooms) {
        return new AnimalClinic(name, rooms);
    }
}