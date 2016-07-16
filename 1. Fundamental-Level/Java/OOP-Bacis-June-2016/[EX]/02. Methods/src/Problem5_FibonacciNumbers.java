import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Problem5_FibonacciNumbers {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        int startRange = Integer.valueOf(reader.readLine());
        int endRange = Integer.valueOf(reader.readLine());
        Fibonacci fibonacci = new Fibonacci();
        List<Long> fibonacciNubmers = fibonacci.getNumbersInRange(startRange, endRange);
        for (int i = 0; i < fibonacciNubmers.size(); i++) {
            if (i + 1 != fibonacciNubmers.size()) {
                System.out.print(fibonacciNubmers.get(i) + ", ");
            } else {
                System.out.print(fibonacciNubmers.get(i));
            }
        }
    }
}

class Fibonacci {

    public List<Long> getNumbersInRange(int startPosition, int endPosition) {
        List<Long> fibonacci = new ArrayList<>();
        long f1 = 0;
        fibonacci.add(f1);
        long f2 = 1;
        fibonacci.add(f2);
        for (int i = 2; i < endPosition; i++) {
            long f3 = f1 + f2;
            fibonacci.add(f3);

            f1 = f2;
            f2 = f3;
        }

        return fibonacci.subList(startPosition, endPosition);
    }
}