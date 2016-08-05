package problem8_PetClinics.IO;

import problem8_PetClinics.contracts.IO.Printable;

public class OutputWriter implements Printable{

    @Override
    public void print(String message) {
        System.out.print(message);
    }

    @Override
    public void printLine(String message) {
        System.out.println(message);
    }
}
