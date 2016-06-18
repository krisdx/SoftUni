package manualStringProcessing;

import java.io.*;

public class Problem1_ReverseString {
    public static void main(String[] args) throws IOException {
        try (
                BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
                BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(System.out))
        ) {
            StringBuilder str = new StringBuilder(reader.readLine());

            int left = 0;
            int right = str.length() - 1;
            while (left <= right) {
                char swapChar = str.charAt(left);
                str.setCharAt(left, str.charAt(right));
                str.setCharAt(right, swapChar);
                left++;
                right--;
            }

            writer.write(str.toString());
            writer.flush();
        }
    }
}