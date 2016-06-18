package ExamPractice_13June;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayDeque;
import java.util.Deque;

public class Problem1_JediMeditations {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        StringBuilder jediMasters = new StringBuilder();
        StringBuilder jediKnights = new StringBuilder();
        StringBuilder padawans = new StringBuilder();
        StringBuilder toshkoAndSlav = new StringBuilder();
        int n = Integer.valueOf(reader.readLine());

        boolean yodaShowsUp = false;
        for (int i = 0; i < n; i++) {
            String[] jedis = reader.readLine().split("\\s+");
            for (int j = 0; j < jedis.length; j++) {
                if (jedis[j].startsWith("m")) {
                    jediMasters.append(jedis[j] + " ");
                } else if (jedis[j].startsWith("k")) {
                    jediKnights.append(jedis[j] + " ");
                } else if (jedis[j].startsWith("p")) {
                    padawans.append(jedis[j] + " ");
                } else if (jedis[j].startsWith("t") ||
                        jedis[j].startsWith("s")) {
                    toshkoAndSlav.append(jedis[j] + " ");
                } else if (jedis[j].startsWith("y")) {
                    yodaShowsUp = true;
                }
            }
        }

        if (!yodaShowsUp) {
            System.out.print(toshkoAndSlav);
            System.out.print(jediMasters);
            System.out.print(jediKnights);
            System.out.print(padawans);
        } else {
            System.out.print(jediMasters);
            System.out.print(jediKnights);
            System.out.print(toshkoAndSlav);
            System.out.print(padawans);
        }
    }
}