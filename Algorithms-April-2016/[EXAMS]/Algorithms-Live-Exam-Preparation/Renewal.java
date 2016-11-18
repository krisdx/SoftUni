package Algorithms_Live_Exam_Preparation;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Renewal {

    private static int n;
    private static int absolteCost;

    public static void main(String[] args) throws IOException {

        List<Route> routes = readInput();

        int minCost = kruskal(routes);
        System.out.println(minCost);
    }

    private static List<Route> readInput() throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );


        n = Integer.valueOf(reader.readLine());
        boolean[][] hasPath = new boolean[n][n];
        for (int i = 0; i < n; i++) {
            String row = reader.readLine();
            for (int j = 0; j < row.length(); j++) {
                hasPath[i][j] = row.charAt(j) == '1';
            }
        }

        int[][] buildPrice = new int[n][n];
        convertLetters(reader, buildPrice);

        int[][] removePrice = new int[n][n];
        convertLetters(reader, removePrice);

        List<Route> routes = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (!hasPath[i][j]) {
                    routes.add(new Route(i, j, buildPrice[i][j]));
                } else {
                    routes.add(new Route(i, j, -removePrice[i][j]));
                    absolteCost += removePrice[i][j];
                }
            }
        }

        return routes;
    }

    private static void convertLetters(BufferedReader reader, int[][] matrix) throws IOException {
        for (int i = 0; i < matrix.length; i++) {
            String row = reader.readLine();
            for (int j = 0; j < row.length(); j++) {
                char letter = row.charAt(j);
                if (Character.isLowerCase(letter)) {
                    matrix[i][j] = (letter - 'a') + 26;
                } else if (Character.isUpperCase(letter)) {
                    matrix[i][j] = (letter - 'A');
                }
            }
        }
    }

    private static int kruskal(List<Route> edges) {
        int[] parent = new int[n];
        for (int i = 0; i < parent.length; i++) {
            parent[i] = i;
        }

        edges.sort((r1, r2) -> Integer.compare(r1.cost, r2.cost));

        int mstCost = 0;
        for (Route edge : edges) {
            int startNodeParent = findRoot(parent, edge.startCity);
            int endNodeParent = findRoot(parent, edge.endCity);
            if (startNodeParent != endNodeParent) {
                mstCost += edge.cost;
                parent[endNodeParent] = startNodeParent;
            }
        }

        return mstCost + absolteCost;
    }

    private static int findRoot(int[] parent, int node) {
        int root = node;
        while (parent[root] != root) {
            root = parent[root];
        }

        // Path compression
        while (root != node) {
            int currentRoot = parent[node];
            parent[node] = root;
            node = currentRoot;
        }

        return root;
    }
}

class Route {
    public int startCity;
    public int endCity;
    public int cost;

    public Route(int startCity, int endCity, int cost) {
        this.startCity = startCity;
        this.endCity = endCity;
        this.cost = cost;
    }
}