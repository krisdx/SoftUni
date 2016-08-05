package main.bg.softuni.dataStructures;

import main.bg.softuni.contracts.SimpleOrderedBag;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Collection;
import java.util.Comparator;
import java.util.Iterator;

public class SimpleSortedList<E extends Comparable<E>> implements SimpleOrderedBag<E> {

    private static final int DEFAULT_SIZE = 16;

    private E[] elements;
    private int size;
    private Comparator<E> comparator;

    public SimpleSortedList(
            Class<E> classType,
            Comparator<E> comparator,
            int capacity) {
        this.initElements(classType, capacity);
        this.comparator = comparator;
    }

    public SimpleSortedList(Class<E> classType, int capacity) {
        this(classType, Comparable::compareTo, capacity);
    }

    public SimpleSortedList(Class<E> classType, Comparator<E> comparator) {
        this(classType, comparator, DEFAULT_SIZE);
    }

    public SimpleSortedList(Class<E> classType) {
        this(classType, Comparable::compareTo, DEFAULT_SIZE);
    }

    @Override
    public boolean remove(E element) {
        if (element == null) {
            throw new IllegalArgumentException("The element to remove cannot be null.");
        }

        boolean hasBeenRemoved = false;
        int indexOfRemovedElement = 0;

        for (int i = 0; i < this.getSize(); i++) {
            if (this.elements[i].compareTo(element) == 0) {
                indexOfRemovedElement = i;
                this.elements[i] = null;
                hasBeenRemoved = true;
                break;
            }
        }

        if (hasBeenRemoved) {
            for (int i = indexOfRemovedElement; i < this.getSize() - 1; i++) {
                this.elements[i] = this.elements[i + 1];
            }

            this.elements[this.getSize() - 1] = null;
            this.size--;
        }

        return hasBeenRemoved;
    }

    @Override
    public int capacity() {
        return this.elements.length;
    }

    @Override
    public void add(E element) {
        if (element == null) {
            throw new IllegalArgumentException("The element cannot be null");
        }

        if (this.getSize() >= this.elements.length) {
            this.resize();
        }

        this.elements[this.getSize()] = element;
        this.size++;
        Arrays.sort(this.elements, 0, this.size, this.comparator);
    }

    @Override
    public void addAll(Collection<E> collection) {
        if (collection == null) {
            throw new IllegalArgumentException("The collection cannot be null.");
        }

        if (this.size + collection.size() >= this.elements.length) {
            this.multiResize(collection);
        }

        for (E element : collection) {
            this.elements[this.getSize()] = element;
            this.size++;
        }

        Arrays.sort(this.elements, 0, this.size, this.comparator);
    }

    @Override
    public int getSize() {
        return this.size;
    }

    @Override
    public Iterator<E> iterator() {
        Iterator<E> iterator = new Iterator<E>() {
            private int index = 0;

            @Override
            public boolean hasNext() {
                return this.index < getSize();
            }

            @Override
            public E next() {
                return elements[this.index++];
            }
        };

        return iterator;
    }

    @Override
    public String joinWith(String joiner) {
        if (joiner == null) {
            throw new IllegalArgumentException("The joiner cannot be null");
        }

        StringBuilder output = new StringBuilder();
        for (E element : this) {
            output.append(element);
            output.append(joiner);
        }

        output.setLength(output.length() - joiner.length());
        return output.toString().trim();
    }

    @SuppressWarnings("unchecked")
    private void initElements(Class<E> classType, int capacity) {
        if (capacity < 0) {
            throw new IllegalArgumentException("Capacity cannot be negative.");
        }

        this.elements = (E[]) Array.newInstance(classType, capacity);
    }

    private void resize() {
        E[] newElements = Arrays.copyOf(
                this.elements,
                this.elements.length * 2);
        this.elements = newElements;
    }

    private void multiResize(Collection<E> collection) {
        int newSize = this.elements.length * 2;
        while (this.size + collection.size() >= newSize) {
            newSize *= 2;
        }

        E[] newElements = Arrays.copyOf(this.elements, newSize);
        this.elements = newElements;
    }
}