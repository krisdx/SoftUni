package problem8_PetClinics.contracts.factories;

import problem8_PetClinics.contracts.Clinic;

public interface ClinicFactory {
    Clinic createClinic(String name, int rooms);
}