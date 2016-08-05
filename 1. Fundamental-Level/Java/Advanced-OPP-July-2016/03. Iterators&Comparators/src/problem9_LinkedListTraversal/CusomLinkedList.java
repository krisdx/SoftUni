package problem9_LinkedListTraversal;

public interface CusomLinkedList<E> extends Iterable<E> {
    void add(E element);

    boolean remove(E element);

    int getSize();
}