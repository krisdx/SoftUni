package problem9_LinkedListTraversal;

import java.util.Iterator;

public class CustomLinkedListImpl<E extends Comparable<E>>
        implements CusomLinkedList<E>, Iterable<E> {

    private CustomLinkedListNode<E> head;
    private int size;

    @Override
    public void add(E element) {
        if (this.head == null) {
            this.head = new CustomLinkedListNode<>(element);
        } else {
            CustomLinkedListNode<E> currentNode = this.head;
            while (currentNode.getNextNode() != null) {
                currentNode = currentNode.getNextNode();
            }

            currentNode.setNextNode(new CustomLinkedListNode<>(element));
        }

        this.size++;
    }

    @Override
    public boolean remove(E elementToRemove) {
        if (this.head.getValue().compareTo(elementToRemove) == 0) {
            this.head = this.head.getNextNode();
            this.size--;
            return true;
        } else {
            CustomLinkedListNode<E> currentNode = this.head;
            while (currentNode.getNextNode() != null) {
                if (currentNode.getNextNode().getValue().compareTo(elementToRemove) == 0) {
                    currentNode.setNextNode(currentNode.getNextNode().getNextNode());
                    this.size--;
                    return true;
                }

                currentNode = currentNode.getNextNode();
            }
        }

        return false;
    }

    @Override
    public int getSize() {
        return this.size;
    }

    @Override
    public Iterator<E> iterator() {
        return new Iterator<E>() {

            CustomLinkedListNode<E> currentNode = head;

            @Override
            public boolean hasNext() {
                return this.currentNode != null;
            }

            @Override
            public E next() {
                CustomLinkedListNode<E> nodeToReturn = currentNode;
                currentNode = currentNode.getNextNode();
                return nodeToReturn.getValue();
            }
        };
    }
}