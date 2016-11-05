import java.util.Scanner;

public class Bridges {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] inputLine = scanner.nextLine().split("\\s+");
        int[] sequence = new int[inputLine.length];
        for (int i = 0; i < inputLine.length; i++) {
            sequence[i] = Integer.valueOf(inputLine[i]);
        }

        boolean[] hasBridge = new boolean[sequence.length];
        int bridgesCount = 0;
        int lastBridgeIndex = -1;
        for (int right = 0; right < sequence.length; right++) {
            for (int left = right - 1; left >= 0; left--) {
                if (left < lastBridgeIndex) {
                    break;
                }

                if (sequence[left] == sequence[right]) {
                    lastBridgeIndex = right;
                    hasBridge[left] = true;
                    hasBridge[right] = true;
                    bridgesCount++;
                }
            }
        }

        if (bridgesCount == 0) {
            System.out.println("No bridges found");
        } else {
            System.out.printf("%d %s found%n", bridgesCount,
                    bridgesCount == 1 ? "bridge" : "bridges");
        }

        for (int i = 0; i < hasBridge.length; i++) {
            System.out.print((hasBridge[i] ? sequence[i] : "X") + " ");
        }
    }
}