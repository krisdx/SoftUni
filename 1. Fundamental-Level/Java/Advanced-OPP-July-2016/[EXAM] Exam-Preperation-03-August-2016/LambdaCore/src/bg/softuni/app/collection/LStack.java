package bg.softuni.app.collection;

import bg.softuni.app.utility.Messages;

import java.util.LinkedList;

public class LStack<E> implements LinkedStack<E> {

    private LinkedList<E> elements;

    public LStack() {
        this.elements = new LinkedList<>();
    }

    @Override
    public int getSize() {
        return this.elements.size();
    }

    @Override
    public void push(E item) {
        this.elements.addLast(item);
    }

    @Override
    public E pop(){
        this.validateEmptyCollection();

        return this.elements.removeLast();
    }

    @Override
    public E peek() {
        this.validateEmptyCollection();

        return this.elements.getLast();
    }

    @Override
    public boolean isEmpty() {
        return this.elements.isEmpty();
    }

    private void validateEmptyCollection() {
        if (this.isEmpty()) {
            throw new UnsupportedOperationException(
                    Messages.EMPTY_COLLECTION_MESSAGE);
        }
    }
}