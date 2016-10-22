import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class Blocks {

	private static char[] currentCombination;
	private static Set<String> rotatedCombinations = new HashSet<>();
	private static StringBuilder output = new StringBuilder();

	private static int totalCount;

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		int n = Integer.valueOf(scanner.nextLine());

		currentCombination = new char[4];
		char[] letters = getLetters(n);

		Set<Character> used = new HashSet<>();
		Generate(letters, 0, used);
		System.out.println("Number of blocks: " + totalCount);
		System.out.print(output.toString().trim());
	}

	private static void Generate(char[] letters, int startIndex, Set<Character> used) {
		if (startIndex >= 4) {
			String currentComb = new String(currentCombination);
			rotatedCombinations.add(currentComb);

			char[] firstRotation = rotateArr(currentComb.toCharArray());
			rotatedCombinations.add(new String(firstRotation));

			char[] secondRotation = rotateArr(firstRotation);
			rotatedCombinations.add(new String(secondRotation));

			char[] thirdRotation = rotateArr(secondRotation);
			rotatedCombinations.add(new String(thirdRotation));

			output.append(currentComb).append(System.lineSeparator());
			totalCount++;
			return;
		}

		for (int currentIndex = 0; currentIndex < letters.length; currentIndex++) {
			if (!used.contains(letters[currentIndex])) {
				currentCombination[startIndex] = letters[currentIndex];
				if (!rotatedCombinations.contains(new String(currentCombination))) {
					used.add(letters[currentIndex]);
					Generate(letters, startIndex + 1, used);
					used.remove(letters[currentIndex]);
				}
			}
		}
	}

	private static char[] rotateArr(char[] arr) {
		char[] newArr = new char[arr.length];
		newArr[0] = arr[2];
		newArr[1] = arr[0];
		newArr[2] = arr[3];
		newArr[3] = arr[1];
		return newArr;
	}

	private static char[] getLetters(int n) {
		char[] letters = new char[n];

		letters[0] = 'A';
		for (int i = 1; i < n; i++) {
			letters[i] = (char) (letters[i - 1] + 1);
		}

		return letters;
	}
}
