package problem8_PetClinics;

import problem8_PetClinics.IO.InputReader;
import problem8_PetClinics.IO.OutputWriter;
import problem8_PetClinics.contracts.factories.AnimalFactory;
import problem8_PetClinics.contracts.ClinicDatabase;
import problem8_PetClinics.contracts.factories.ClinicFactory;
import problem8_PetClinics.contracts.IO.Printable;
import problem8_PetClinics.contracts.IO.Readable;
import problem8_PetClinics.core.AnimalClinicEngine;
import problem8_PetClinics.core.factories.ClinicFactoryImpl;
import problem8_PetClinics.core.factories.PetFactory;
import problem8_PetClinics.data.ClinicDatabaseImpl;

public class Main {

    public static void main(String[] args) {
        Printable writer = new OutputWriter();
        Readable reader = new InputReader();

        AnimalFactory petFactory = new PetFactory();
        ClinicFactory clinicFactory = new ClinicFactoryImpl();
        ClinicDatabase clinicDatabase = new ClinicDatabaseImpl(clinicFactory, petFactory);

        Runnable engine = new AnimalClinicEngine(clinicDatabase, writer, reader);
        engine.run();
    }
}