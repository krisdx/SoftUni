package problem3_StackIterator;

import java.util.Iterator;
import java.util.NoSuchElementException;

public class CustomStack<E> implements Iterable<E> {

    private E[] elemets;
    private int index;

    public CustomStack() {
        this.elemets = (E[]) new Object[10];
    }

    public int getSize() {
        return this.index + 1;
    }

    public void push(E element) {
        if (this.index >= this.elemets.length) {
            this.resize();
        }

        this.elemets[this.index] = element;
        this.index++;
    }

    public E pop() {
        if (this.index == 0) {
            throw new NoSuchElementException("No elements");
        }

        this.index--;
        E elementToRemove = this.elemets[this.index];
        this.elemets[this.index] = null;
        return elementToRemove;
    }

    private void resize() {
        E[] newArr = (E[]) new Object[this.elemets.length * 2];
        for (int i = 0; i < this.elemets.length; i++) {
            newArr[i] = this.elemets[i];
        }

        this.elemets = newArr;
    }

    @Override
    public Iterator<E> iterator() {
        return new Iterator<E>() {
            private int currentIndex = index - 1;

            @Override
            public boolean hasNext() {
                return this.currentIndex >= 0;
            }

            @Override
            public E next() {
                if (this.hasNext()) {
                    return elemets[this.currentIndex--];
                }

                throw new NoSuchElementException();
            }
        };
    }
}