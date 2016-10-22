import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class ZigZag_Matrix {

	private static int[][] matrix;

	private static long[][] sums;
	private static Cell[][] prev;

	public static void main(String[] args) {
		readMatrix();

		calcOptimalSum();
		recoverPath();
	}

	private static void recoverPath() {
		int endRow = 0;

		long maxSum = Long.MIN_VALUE;
		for (int row = 0; row < sums.length; row++) {
			long currentSum = sums[row][matrix[row].length - 1];
			if (currentSum > maxSum) {
				endRow = row;
				maxSum = currentSum;
			}
		}

		List<Integer> nums = new ArrayList<>();

		nums.add(matrix[endRow][matrix[endRow].length - 1]);
		Cell currentCell = prev[endRow][matrix[endRow].length - 1];
		while (currentCell != null) {
			nums.add(matrix[currentCell.row][currentCell.col]);
			currentCell = prev[currentCell.row][currentCell.col];
		}

		System.out.print(maxSum + " = ");
		for (int i = nums.size() - 1; i >= 0; i--) {
			if (i == 0) {
				System.out.print(nums.get(i));
			} else {
				System.out.print(nums.get(i) + " + ");
			}
		}
	}

	private static void calcOptimalSum() {
		for (int row = 0; row < sums.length; row++) {
			sums[row][0] = matrix[row][0];
		}

		for (int row = 0; row < sums.length; row++) {
			for (int col = 1; col < sums[row].length; col++) {
				sums[row][col] = -1;
			}
		}

		boolean searchUp = true;
		for (int col = 1; col < sums[0].length; col++) {
			for (int row = 0; row < sums.length; row++) {
				if (searchUp) {
					for (int row2 = row + 1; row2 < sums.length; row2++) {
						long sum = matrix[row][col] + sums[row2][col - 1];
						if (sum > sums[row][col]) {
							sums[row][col] = sum;
							prev[row][col] = new Cell(row2, col - 1);
						}
					}
				} else {
					for (int row2 = 0; row2 <= row - 1; row2++) {
						long sum = matrix[row][col] + sums[row2][col - 1];
						if (sum > sums[row][col]) {
							sums[row][col] = sum;
							prev[row][col] = new Cell(row2, col - 1);
						}
					}
				}
			}

			searchUp = !searchUp;
		}
	}

	private static void readMatrix() {
		Scanner scanner = new Scanner(System.in);

		int rows = Integer.valueOf(scanner.nextLine());
		int cols = Integer.valueOf(scanner.nextLine());

		matrix = new int[rows][cols];
		sums = new long[rows][cols];
		prev = new Cell[rows][cols];

		for (int i = 0; i < rows; i++) {
			String[] row = scanner.nextLine().split(",");
			for (int j = 0; j < cols; j++) {
				matrix[i][j] = Integer.valueOf(row[j]);
			}
		}
	}
}

class Cell {
	public Integer row;
	public Integer col;

	public Cell(int row, int col) {
		this.row = row;
		this.col = col;
	}

	@Override
	public String toString() {
		return row + "," + col;
	}
}