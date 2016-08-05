package problem1_ListIterator;

import java.util.List;

public class CustomListIterator<E> implements CutstomIterator<E> {

    private int index;
    private List<E> elements;

    public CustomListIterator(List<E> collection) {
        this.index = 0;
        this.elements = collection;
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
    public E printCurrentElement() {
        if (this.elements.size() == 0) {
            throw new RuntimeException("Invalid Operation!");
        }

        return this.elements.get(this.index);
    }
}