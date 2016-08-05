package problem1_Database;

import javax.naming.OperationNotSupportedException;

public class IntegerDatabase implements Database {

    private Integer[] elements;

    public IntegerDatabase(Integer... elements) {
        this.elements = elements;
    }

    @Override
    @SuppressWarnings("unchecked")
    public void add(Integer elementToAdd) throws OperationNotSupportedException {
        if (elementToAdd == null) {
            throw new OperationNotSupportedException("The database is empty.");
        }

        Integer[] newElements =  new Integer[this.elements.length + 1];
        for (int i = 0; i < this.elements.length; i++) {
            newElements[i] = this.elements[i];
        }

        newElements[this.elements.length] = elementToAdd;
        this.elements = newElements;
    }

    @Override
    @SuppressWarnings("unchecked")
    public Integer remove() throws OperationNotSupportedException {
        if (this.elements.length == 0) {
            throw new OperationNotSupportedException("The database is empty.");
        }

        Integer elementToRemove = this.elements[this.elements.length - 1];
        Integer[] newElements = new Integer[this.elements.length - 1];
        for (int i = 0; i < this.elements.length - 1; i++) {
            newElements[i] = this.elements[i];
        }

        this.elements = newElements;
        return elementToRemove;
    }

    @Override
    public Integer[] fetch() {
        return this.elements;
    }
}
