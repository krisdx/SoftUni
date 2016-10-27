import java.util.*;

public class GraphCycles {

    private static Map<Integer, List<Integer>> graph;

    public static void main(String[] args) {
        buildGraph();
        findCycles();
    }

    private static void findCycles() {
        boolean solutionFound = false;
        for (int nodeA = 0; nodeA < graph.size(); nodeA++) {
            for (int nodeB : graph.get(nodeA)) {
                if (nodeB > nodeA) {
                    for (int nodeC : graph.get(nodeB)) {
                        if (nodeC > nodeA && nodeB != nodeC) {
                            if (graph.get(nodeC).contains(nodeA)) {
                                System.out.printf("{%d -> %d -> %d}%n", nodeA, nodeB, nodeC);
                                solutionFound = true;
                            }
                        }
                    }
                }
            }
        }

        if (!solutionFound) {
            System.out.println("No cycles found");
        }
    }

    private static void buildGraph() {
        graph = new TreeMap<>();
        Scanner scanner = new Scanner(System.in);
        int n = Integer.valueOf(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            String[] lineArgs = scanner.nextLine().split("->");
            int sourceNode = Integer.valueOf(lineArgs[0].trim());
            graph.put(sourceNode, new ArrayList<>());
            if (lineArgs.length == 1) {
                continue;
            }

            Set<Integer> currentNeighbors = new HashSet<>();
            String[] neighbors = lineArgs[1].trim().split(" ");
            for (int j = 0; j < neighbors.length; j++) {
                int neighbor = Integer.valueOf(neighbors[j]);
                if (!currentNeighbors.contains(neighbor)) {
                    currentNeighbors.add(neighbor);
                    graph.get(sourceNode).add(neighbor);
                }
            }

            Collections.sort(graph.get(sourceNode));
        }
    }
}