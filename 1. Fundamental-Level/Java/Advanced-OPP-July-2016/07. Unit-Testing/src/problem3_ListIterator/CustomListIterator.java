package problem3_ListIterator;

import javax.naming.OperationNotSupportedException;
import java.util.Arrays;
import java.util.Collection;
import java.util.List;

public class CustomListIterator<E> implements CustomIterator<E> {

    private int index;
    private List<E> elements;

    public CustomListIterator(List<E> collection) {
        this.index = 0;
        this.elements = collection;
    }

    @SafeVarargs
    public CustomListIterator(E... collection) {
        this.index = 0;
        this.elements = Arrays.asList(collection);
    }

    @Override
    public boolean move() {
        if (this.hasNext()) {
            this.index++;
            return true;
        }

        return false;
    }

    @Override
    public boolean hasNext() {
        return this.index < this.elements.size() - 1;
    }

    @Override
    public E print() throws OperationNotSupportedException {
        if (this.elements.size() == 0) {
            throw new OperationNotSupportedException("The is no current element.");
        }

        return this.elements.get(this.index);
    }
}