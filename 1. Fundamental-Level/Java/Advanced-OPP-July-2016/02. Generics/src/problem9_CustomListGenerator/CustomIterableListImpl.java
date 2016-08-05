package problem9_CustomListGenerator;

import java.util.*;
import java.util.function.Consumer;

public class CustomIterableListImpl<E extends Comparable<E>> implements CustomIterableList<E> {
    private List<E> elements;

    public CustomIterableListImpl() {
        this.elements = new ArrayList<>();
    }

    @Override
    public void add(E element) {
        this.elements.add(element);
    }

    @Override
    public E removeElement(int index) {
        E elementToRemove = this.elements.get(index);
        this.elements.remove(index);
        return elementToRemove;
    }

    @Override
    public boolean contains(E element) {
        return this.elements.contains(element);
    }

    @Override
    public void swap(int firstIndex, int secondIndex) {
        E swapValue = this.elements.get(firstIndex);
        this.elements.set(firstIndex, this.elements.get(secondIndex));
        this.elements.set(secondIndex, swapValue);
    }

    @Override
    public int countGreaterThan(E element) {
        int count = 0;
        for (E currentElement : this.elements) {
            if (currentElement.compareTo(element) > 0) {
                count++;
            }
        }

        return count;
    }

    @Override
    public E getMax() {
        E maxElement = this.elements.get(0);
        for (int i = 1; i < this.elements.size(); i++) {
            E currentElement = this.elements.get(i);
            if (maxElement.compareTo(currentElement) < 0) {
                maxElement = currentElement;
            }
        }

        return maxElement;
    }

    @Override
    public E getMin() {
        E minElement = this.elements.get(0);
        for (int i = 1; i < this.elements.size(); i++) {
            E currentElement = this.elements.get(i);
            if (minElement.compareTo(currentElement) > 0) {
                minElement = currentElement;
            }
        }

        return minElement;
    }

    @Override
    public void sort() {
        Collections.sort(this.elements);
    }

    @Override
    public Iterator<E> iterator() {
        return this.elements.iterator();
    }

    @Override
    public void forEach(Consumer<? super E> action) {
        this.elements.forEach(action::accept);
    }

    @Override
    public Spliterator<E> spliterator() {
        return null;
    }
}