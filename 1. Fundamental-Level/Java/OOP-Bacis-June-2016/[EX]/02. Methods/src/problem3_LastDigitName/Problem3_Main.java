package problem3_LastDigitName;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.*;

public class Problem3_Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        int n= Integer.valueOf(reader.readLine());
        Number number = new Number(n);
        System.out.println(number);
    }
}
