package problem8_PetClinics.IO;

import problem8_PetClinics.contracts.IO.Readable;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class InputReader implements Readable {
    private BufferedReader bufferedReader;

    public InputReader() {
        this.bufferedReader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );
    }

    @Override
    public String read() throws IOException {
        return bufferedReader.readLine();
    }
}