package problem5_GenericCountMethodStrings;

import java.util.List;

public class GenericStringBox<T> {

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