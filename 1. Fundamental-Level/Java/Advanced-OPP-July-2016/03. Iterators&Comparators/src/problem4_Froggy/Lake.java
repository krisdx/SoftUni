package problem4_Froggy;

import java.util.Iterator;
import java.util.List;

public class Lake<E> implements Iterable<E> {

    private List<E> elements;

    public Lake(List<E> elements) {
        this.elements = elements;
    }

    @Override
    public Iterator<E> iterator() {
        return new FrogIterator<>();
    }

    private class FrogIterator<E> implements Iterator<E> {

        private int index;
        private boolean lastIteration;

        @Override
        public boolean hasNext() {
            return (this.index < elements.size()&& this.lastIteration) ||
                    (this.index < elements.size() && !this.lastIteration);
        }

        @Override
        @SuppressWarnings("unchecked")
        public E next() {
            E element = (E) elements.get(this.index);
            this.index += 2;
            this.checkIndex();

            return element;
        }

        private void checkIndex() {
            if (this.index >= elements.size()) {
                if (this.lastIteration) {
                    this.index = Integer.MAX_VALUE;
                } else {
                    this.index = 1;
                    this.lastIteration = true;
                }
            }
        }
    }
}