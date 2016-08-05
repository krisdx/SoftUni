package problem8_CustomListSorter;

public interface CustomSortableList<E> extends Sortable<E> {
    void add(E element);

    E removeElement(int index);

    boolean contains(E element);

    void swap(int firstIndex, int secondIndex);

    int countGreaterThan(E element);

    E getMax();

    E getMin();
}