package problem9_CustomListGenerator;

import java.util.Iterator;

public interface CustomIterableList<E> extends Iterable<E> {
    void add(E element);

    E removeElement(int index);

    boolean contains(E element);

    void swap(int firstIndex, int secondIndex);

    int countGreaterThan(E element);

    E getMax();

    E getMin();

    void sort();
}