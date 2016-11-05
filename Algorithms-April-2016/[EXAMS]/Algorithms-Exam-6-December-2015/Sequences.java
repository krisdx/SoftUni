import java.util.Scanner;

public class Sequences {

	private static StringBuilder output = new StringBuilder();
	private static int targetSum;

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);

		targetSum = scanner.nextInt();
		int[] arr = initArr(targetSum);
		generateSums(arr, new int[targetSum], 0);
		System.out.println(output);
	}

	private static void generateSums(int[] arr, int[] copyArr, int index) {
		if (index >= arr.length) {
			return;
		}

		for (int i = 1; i <= arr.length; i++) {
			copyArr[index] = arr[i - 1];
			if (sum(copyArr) <= targetSum) {
				print(copyArr);
			} else {
				copyArr[index] = 0;
				return;
			}

			generateSums(arr, copyArr, index + 1);
		}
	}

	private static void print(int[] copyArr) {
		for (int num : copyArr) {
			if (num != 0) {
				output.append(num + " ");
			}
		}

		output.append("\n");
	}

	private static int sum(int[] arr) {
		int sum = 0;
		for (int i = 0; i < arr.length; i++) {
			sum += arr[i];
		}

		return sum;
	}

	private static int[] initArr(int n) {
		int[] arr = new int[n];
		for (int i = 1; i <= n; i++) {
			arr[i - 1] = i;
		}

		return arr;
	}
}