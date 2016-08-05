package problem2_Collection;

public interface CustomIterableInterface<E>  extends Iterable<E> {
    boolean move();

    boolean hasNext();

    E printCurrentElement();

    void printAll();
}