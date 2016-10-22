import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Needles {

	private static List<Integer> indexes = new ArrayList<>();

	public static void main(String[] args) throws IOException {

		BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

		String line = reader.readLine();
		String[] inputNumbers = reader.readLine().split(" ");
		int[] numbers = new int[inputNumbers.length];
		for (int i = 0; i < inputNumbers.length; i++) {
			numbers[i] = Integer.valueOf(inputNumbers[i]);
		}

		String[] inputNeedles = reader.readLine().split(" ");
		int[] needles = new int[inputNeedles.length];
		for (int i = 0; i < inputNeedles.length; i++) {
			needles[i] = Integer.valueOf(inputNeedles[i]);
		}

		for (int i = 0; i < needles.length; i++) {

			boolean hasFound = false;
			for (int j = 0; j < numbers.length; j++) {
				if (numbers[j] >= needles[i]) {
					returnIndex(numbers, j - 1);
					hasFound = true;
					break;
				}
			}

			if (!hasFound) {
				returnIndex(numbers, numbers.length - 1);
			}
		}

		for (int i = 0; i < indexes.size(); i++) {
			System.out.print(indexes.get(i) + " ");
		}
	}

	private static void returnIndex(int[] numbers, int index) {

		while (index >= 0) {
			if (numbers[index] != 0) {
				indexes.add(index + 1);
				return;
			}

			index--;
		}

		indexes.add(0);
	}
}