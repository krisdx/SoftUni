package stacksAndQueues;

import java.util.ArrayDeque;
import java.util.Queue;
import java.util.Scanner;

public class Problem5_SequenceWithQueue {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        long n = input.nextLong();

        Queue<Long> queue = new ArrayDeque<>();
        queue.add(n);
        for (int i = 0; i < 50; i++) {
            long s = queue.remove();
            System.out.print(s + " ");

            long s1 = s + 1;
            long s2 = (2 * s) + 1;
            long s3 = s + 2;
            queue.add(s1);
            queue.add(s2);
            queue.add(s3);
        }
    }
}