package problem7_CustomList;

public interface CustomList<E> {
    void add(E element);

    E removeElement(int index);

    boolean contains(E element);

    void swap(int firstIndex, int secondIndex);

    int countGreaterThan(E element);

    E getMax();

    E getMin();
}