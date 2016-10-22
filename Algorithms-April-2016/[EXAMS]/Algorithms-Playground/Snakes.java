import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class Snakes {

	private static final Character RIGHT = 'R';
	private static final Character DOWN = 'D';
	private static final Character LEFT = 'L';
	private static final Character UP = 'U';

	private static boolean[][] visited = new boolean[30][30];
	private static Set<String> allSnakes = new HashSet<>();
	private static StringBuilder resultSnakes = new StringBuilder();
	private static int resultSnakesCout;

	private static int n;

	public static void main(String[] args) {
		
		 int arr[] = {10, 20, 30, 40, 50};
	       for(int i=0; i < arr.length; i++)
	       {
	             System.out.print(" " + arr[i]);              
	       }
	       
//		n = new Scanner(System.in).nextInt();
//
//		String snake = "";
//		visited[visited.length / 2][visited.length / 2] = true;
//		go('S', snake, visited.length / 2, visited.length / 2, 1);
//
//		System.out.println(resultSnakes.toString().trim());
//		System.out.print("Snakes count = " + resultSnakesCout);
	}

	private static void go(Character currentDirection, String snake, int row, int col, int moves) {

		snake += currentDirection;
		if (moves == n) {
			if (!allSnakes.contains(snake)) {
				resultSnakes.append(snake).append("\n");
				resultSnakesCout++;
				markSnakes(snake);
			}

			return;
		}

		if (!visited[row][col + 1]) {
			visited[row][col + 1] = true;
			go(RIGHT, snake, row, col + 1, moves + 1);
			visited[row][col + 1] = false;
		}

		if (snake.length() == 1) {
			// We need only the snakes that start with SR
			return;
		}

		if (!visited[row + 1][col]) {
			visited[row + 1][col] = true;
			go(DOWN, snake, row + 1, col, moves + 1);
			visited[row + 1][col] = false;
		}

		if (!visited[row][col - 1]) {
			visited[row][col - 1] = true;
			go(LEFT, snake, row, col - 1, moves + 1);
			visited[row][col - 1] = false;
		}

		if (!visited[row - 1][col]) {
			visited[row - 1][col] = true;
			go(UP, snake, row - 1, col, moves + 1);
			visited[row - 1][col] = false;
		}
	}

	private static void markSnakes(String snake) {
		allSnakes.add(snake);
		allSnakes.add(flip(snake));

		String reversed = reverse(snake);
		while (reversed.charAt(1) != RIGHT) {
			reversed = rotate(reversed);
		}

		allSnakes.add(reversed);
		allSnakes.add(flip(reversed));
	}

	private static String rotate(String snake) {
		StringBuilder rotatedSnake = new StringBuilder(snake);
		for (int i = 1; i < snake.length(); i++) {
			if (snake.charAt(i) == RIGHT) {
				rotatedSnake.setCharAt(i, DOWN);
			} else if (snake.charAt(i) == DOWN) {
				rotatedSnake.setCharAt(i, LEFT);
			} else if (snake.charAt(i) == LEFT) {
				rotatedSnake.setCharAt(i, UP);
			} else if (snake.charAt(i) == UP) {
				rotatedSnake.setCharAt(i, RIGHT);
			}
		}

		return rotatedSnake.toString();
	}

	private static String flip(String snake) {
		StringBuilder flippedSnake = new StringBuilder(snake);
		for (int i = 1; i < snake.length(); i++) {
			if (snake.charAt(i) == DOWN) {
				flippedSnake.setCharAt(i, UP);
			} else if (snake.charAt(i) == UP) {
				flippedSnake.setCharAt(i, DOWN);
			}
		}

		return flippedSnake.toString();
	}

	private static String reverse(String snake) {
		StringBuilder reversedSnake = new StringBuilder("S");
		for (int i = snake.length() - 1; i >= 1; i--) {
			reversedSnake.append(snake.charAt(i));
		}

		return reversedSnake.toString();
	}
}