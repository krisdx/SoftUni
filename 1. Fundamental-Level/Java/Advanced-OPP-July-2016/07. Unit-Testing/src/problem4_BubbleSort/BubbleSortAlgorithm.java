package problem4_BubbleSort;

import java.util.Collections;
import java.util.List;

public class BubbleSortAlgorithm {

    public static <E extends Comparable<E>> void sort(List<E> collection) {
        performBubbleSort(collection);
    }

    private static <E extends Comparable<E>> void performBubbleSort(
            List<E> collection) {

        boolean areSorted = false;
        while (!areSorted) {
            areSorted = true;

            for (int i = 0; i < collection.size() - 1; i++) {
                E a = collection.get(i);
                E b = collection.get(i + 1);
                if (a.compareTo(b) > 0) {
                    Collections.swap(collection, i, i + 1);
                    areSorted = false;
                }
            }
        }
    }
}