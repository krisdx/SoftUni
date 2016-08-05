package bg.softuni.app.collection;

public interface LinkedStack<E> {

    void push(E item);

    E pop();

    E peek();

    int getSize();

    boolean isEmpty();
}