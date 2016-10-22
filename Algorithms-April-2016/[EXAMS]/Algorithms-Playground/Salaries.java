import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Scanner;
import java.util.Set;

public class Salaries {

	private static List<List<Integer>> graph;
	private static Set<Integer> visited;
	private static Map<Integer, Long> salaries;
	private static long salarySum = 0;

	public static void main(String[] args) {
		buildGraph();
		solve();
		sumSalaries();

		System.out.println(salarySum);
	}

	private static void sumSalaries() {
		for (Map.Entry<Integer, Long> salary : salaries.entrySet()) {
			salarySum += salary.getValue();
		}
	}

	private static void solve() {
		visited = new HashSet<>();
		salaries = new HashMap<>();
		for (int i = 0; i < graph.size(); i++) {
			if (!visited.contains(i)) {
				dfs(i);
			}
		}
	}

	private static void dfs(int node) {
		if (visited.contains(node)) {
			return;
		}

		if (graph.get(node).size() == 0) {
			salaries.put(node, 1L);
			return;
		}

		visited.add(node);
		for (int i = 0; i < graph.get(node).size(); i++) {
			int neighbor = graph.get(node).get(i);
			dfs(neighbor);

			if (!salaries.containsKey(node)) {
				salaries.put(node, 0L);
			}

			salaries.put(node, salaries.get(node) + salaries.get(neighbor));
		}
	}

	private static void buildGraph() {
		Scanner scanner = new Scanner(System.in);

		int n = Integer.valueOf(scanner.nextLine());
		graph = new ArrayList<>();
		for (int i = 0; i < n; i++) {
			graph.add(new ArrayList<>());
			String predecessors = scanner.nextLine();
			for (int j = 0; j < predecessors.length(); j++) {
				if (predecessors.charAt(j) == 'Y') {
					graph.get(i).add(j);
				}
			}
		}
	}
}