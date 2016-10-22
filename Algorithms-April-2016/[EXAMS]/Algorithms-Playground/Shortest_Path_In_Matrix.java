import java.util.*;

public class Shortest_Path_In_Matrix {

    private static int rows;
    private static int cols;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        rows = Integer.valueOf(scanner.nextLine());
        cols = Integer.valueOf(scanner.nextLine());
        long[][] matrix = new long[rows][cols];

        for (int i = 0; i < rows; i++) {
            String[] row = scanner.nextLine().split(" ");
            for (int j = 0; j < cols; j++) {
                matrix[i][j] = Long.valueOf(row[j]);
            }
        }

        Cell[][] graph = new Cell[rows][cols];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                graph[i][j] = new Cell(i, j);
            }
        }

        List<Long> path = dijkstra(matrix, graph);
        long length = 0;
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < path.size(); i++) {
            length += path.get(i);
            output.append(path.get(i)).append(" ");
        }

        System.out.println("Length: " + length);
        System.out.println("Path: " + output.toString().trim());
    }

    private static List<Long> dijkstra(long[][] matrix, Cell[][] graph) {
        PriorityQueue<Cell> priorityQueue = new PriorityQueue<>();

        boolean[][] visited = new boolean[rows][cols];
        Cell[][] prev = new Cell[rows][cols];

        graph[0][0].setDistance(0);
        visited[0][0] = true;
        priorityQueue.add(graph[0][0]);
        while (priorityQueue.size() > 0) {
            Cell currentCell = priorityQueue.poll();
            if (currentCell.getRow() == rows - 1 &&
                    currentCell.getCol() == cols - 1) {
                return reconstructPath(currentCell, matrix, prev);
            }

            List<Cell> neighbors = getNeighbors(graph, currentCell);
            for (Cell neighbor : neighbors) {
                int neighborRow = neighbor.getRow();
                int neighborCol = neighbor.getCol();
                if (!visited[neighborRow][neighborCol]) {
                    priorityQueue.add(neighbor);
                    visited[neighborRow][neighborCol] = true;
                }

                long neighborCellValue = matrix[neighbor.getRow()][neighbor.getCol()];
                long distance = currentCell.getDistance() + neighborCellValue;
                if (distance <= neighbor.getDistance()) {
                    neighbor.setDistance(distance);
                    prev[neighbor.getRow()][neighbor.getCol()] =
                            graph[currentCell.getRow()][currentCell.getCol()];

                    priorityQueue.remove(neighbor);
                    priorityQueue.add(neighbor);
                }
            }
        }

        return null;
    }

    private static List<Long> reconstructPath(Cell lastCell, long[][] matrix, Cell[][] prev) {
        List<Long> path = new ArrayList<>();

        Cell currentCell = prev[rows - 1][cols - 1];
        while (currentCell != null) {
            path.add(matrix[currentCell.getRow()][currentCell.getCol()]);
            currentCell = prev[currentCell.getRow()][currentCell.getCol()];
        }

        Collections.reverse(path);
        path.add(matrix[lastCell.getRow()][lastCell.getCol()]);
        return path;
    }

    private static List<Cell> getNeighbors(Cell[][] graph, Cell currentCell) {
        List<Cell> neighbors = new ArrayList<>();

        int currentRow = currentCell.getRow();
        int currentCol = currentCell.getCol();

        if (isInside(currentRow, currentCol + 1)) {
            neighbors.add(graph[currentRow][currentCol + 1]);
        }

        if (isInside(currentRow - 1, currentCol)) {
            neighbors.add(graph[currentRow - 1][currentCol]);
        }

        if (isInside(currentRow, currentCol - 1)) {
            neighbors.add(graph[currentRow][currentCol - 1]);
        }

        if (isInside(currentRow + 1, currentCol)) {
            neighbors.add(graph[currentRow + 1][currentCol]);
        }

        return neighbors;
    }

    private static boolean isInside(int row, int col) {
        if (row < 0 || row >= rows ||
                col < 0 || col >= cols) {
            return false;
        }

        return true;
    }
}

class Cell implements Comparable<Cell> {
    private int row;
    private int col;
    private long distance;

    public Cell(int row, int col) {
        this.row = row;
        this.col = col;
        this.distance = Long.MAX_VALUE;
    }

    public int getRow() {
        return this.row;
    }

    public int getCol() {
        return this.col;
    }

    public long getDistance() {
        return this.distance;
    }

    public void setDistance(long distance) {
        this.distance = distance;
    }

    @Override
    public int compareTo(Cell other) {
        return Double.compare(this.distance, other.distance);
    }

    @Override
    public String toString() {
        return this.row + "," + this.col;
    }
}