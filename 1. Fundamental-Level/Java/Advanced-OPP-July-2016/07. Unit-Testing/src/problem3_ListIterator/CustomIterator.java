package problem3_ListIterator;

import javax.naming.OperationNotSupportedException;

public interface CustomIterator<E> {
    boolean move();

    boolean hasNext();

    E print() throws OperationNotSupportedException;
}