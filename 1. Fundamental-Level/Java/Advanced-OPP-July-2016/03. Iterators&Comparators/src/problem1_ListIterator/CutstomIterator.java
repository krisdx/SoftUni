package problem1_ListIterator;

public interface CutstomIterator<E> {
    boolean move();

    boolean hasNext();

    E printCurrentElement();
}