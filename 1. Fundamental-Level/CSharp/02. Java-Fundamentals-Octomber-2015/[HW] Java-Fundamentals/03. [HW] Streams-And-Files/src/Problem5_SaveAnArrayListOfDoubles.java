import java.util.Scanner;
import java.util.ArrayList;
import java.io.*;

public class Problem5_SaveAnArrayListOfDoubles {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.println("Enter floating point numbers, separated by space: ");
        String[] doublesInString = input.nextLine().split(" ");
        ArrayList<Double> doubleList = new ArrayList<>();
        for (int i = 0; i < doublesInString.length; i++) {
            doubleList.add(Double.parseDouble(doublesInString[i]));
        }

        saveListOfDoubles(doubleList);
        loadListOfDoubles(doubleList.size());
    }

    private static void loadListOfDoubles(int numberOfNumbers) {
        try (ObjectInputStream objectInputStream = new ObjectInputStream(new FileInputStream("resources/doubles.list"))) {
            for (int i = 0; i < numberOfNumbers; i++) {
                System.out.print(objectInputStream.readDouble() + " ");
            }
        } catch (FileNotFoundException fileNotFoundException) {
            System.out.println("File not found.");
        } catch (IOException exception) {
            System.out.println("Cannot read the file.");
        }
    }

    private static void saveListOfDoubles(ArrayList<Double> doubleList) {
        try (ObjectOutputStream objectInputStream = new ObjectOutputStream(new FileOutputStream("resources/doubles.list"))) {
            for (int i = 0; i < doubleList.size(); i++) {
                objectInputStream.writeDouble(doubleList.get(i));
            }
        } catch (FileNotFoundException fileNotFoundException) {
            System.out.println("File not found.");
        } catch (IOException exception) {
            System.out.println("Cannot read the file.");
        }
    }
}