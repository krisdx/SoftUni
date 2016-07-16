import com.sun.org.apache.bcel.internal.classfile.ClassFormatException;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.reflect.Constructor;
import java.lang.reflect.Field;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class Problem6_PrimeChecker {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        int n = Integer.valueOf(reader.readLine());
        Number number = new Number(n, false);
        System.out.print(number.getNextPrime(number.getNumber()));
        System.out.print(", ");
        System.out.println(number.getPrime());

        Field[] fields = Number.class.getDeclaredFields();
        List<Field> fieldsDeclared = Arrays.stream(fields)
                .filter(f -> f.getName().toLowerCase().contains("prime") || f.getName().contains("number"))
                .collect(Collectors.toList());
        List<Constructor<?>> constructors = Arrays.stream(Number.class.getDeclaredConstructors())
                .filter(c -> c.getParameterCount() > 1)
                .collect(Collectors.toList());
        if (fieldsDeclared.size() <= 1 || constructors.size() < 1) {
            throw new ClassFormatException();
        }

    }
}

class Number {
    private Integer number;
    private Boolean isPrime;

    public Number(Integer number, Boolean isPrime) {
        this.number = number;
        this.isPrime = this.isPrime(number);
    }

    public Integer getNextPrime(int num) {
        while (true) {
            num++;
            if (this.isPrime(num)) {
                return num;
            }
        }
    }

    public Boolean isPrime(int number) {
        for (int i = 2; i <= Math.sqrt(number); i++) {
            if (number % i == 0) {
                return false;
            }
        }

        return true;
    }

    public Boolean getPrime() {
        return this.isPrime;
    }

    public Integer getNumber() {
        return this.number;
    }
}