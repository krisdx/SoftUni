package problem7_CustomList;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class CustomListImpl<E extends Comparable<E>> implements CustomList<E> {
    private List<E> elements;

    public CustomListImpl() {
        this.elements = new ArrayList<>();
    }

    @Override
    public void add(E element) {
        this.elements.add(element);
    }

    @Override
    public E removeElement(int index) {
        return this.elements.remove(index);
    }

    @Override
    public boolean contains(E element) {
        return this.elements.contains(element);
    }

    @Override
    public void swap(int firstIndex, int secondIndex) {
        Collections.swap(this.elements, firstIndex, secondIndex);
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
            if (maxElement.compareTo(currentElement) <= 0) {
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
            if (minElement.compareTo(currentElement) >= 0) {
                minElement = currentElement;
            }
        }

        return minElement;
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        for (E element : this.elements) {
            output.append(element.toString())
                    .append(System.lineSeparator());
        }

        return output.toString().trim();
    }
}