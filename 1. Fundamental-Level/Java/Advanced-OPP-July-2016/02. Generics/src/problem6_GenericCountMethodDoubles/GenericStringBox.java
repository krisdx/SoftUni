package problem6_GenericCountMethodDoubles;

import java.util.List;

public class GenericStringBox {

    public static <T extends Comparable<T>> int getBiggerElementsCount(
            List<T> elements, T elementToCompare) {
        int count = 0;
        for (T currentElement : elements) {
            if (currentElement.compareTo(elementToCompare) > 0) {
                count++;
            }
        }

        return count;
    }
}