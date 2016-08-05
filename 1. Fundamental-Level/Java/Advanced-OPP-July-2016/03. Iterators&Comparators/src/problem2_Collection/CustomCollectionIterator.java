package problem2_Collection;

import java.util.Iterator;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.Spliterator;
import java.util.function.Consumer;

public class CustomCollectionIterator<E> implements CustomIterableInterface<E> {

    private int index;
    private List<E> elements;

    public CustomCollectionIterator(List<E> elements) {
        this.elements = elements;
    }

    @Override
    public Iterator<E> iterator() {
        return new Iterator<E>() {
            private int index;

            @Override
            public boolean hasNext() {
                return this.index < elements.size();
            }

            @Override
            public E next() {
                return elements.get(this.index++);
            }
        };
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

    @Override
    public void printAll() {
        for (E element : this) {
            System.out.print(element + " ");
        }
    }
}