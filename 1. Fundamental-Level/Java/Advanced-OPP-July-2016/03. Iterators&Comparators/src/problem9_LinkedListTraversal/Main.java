package problem9_LinkedListTraversal;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) throws IOException {


        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        CusomLinkedList<Integer> linkedList = new CustomLinkedListImpl<>();
        int n = Integer.valueOf(reader.readLine());
        for (int i = 0; i < n; i++) {
            String[] lineArgs = reader.readLine().split("\\s+");
            String command = lineArgs[0];
            int value = Integer.valueOf(lineArgs[1]);
            if (command.equals("Add")) {
                linkedList.add(value);
            } else if (command.equals("Remove")) {
                linkedList.remove(value);
            }
        }

        System.out.println(linkedList.getSize());
        for (Integer number : linkedList) {
            System.out.print(number + " ");
        }
    }
}