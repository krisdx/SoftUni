package problem9_LinkedListTraversal;

public class CustomLinkedListNode<E extends Comparable<E>> implements Comparable<CustomLinkedListNode<E>>{
    private E value;

    private CustomLinkedListNode<E> nextNode;

    public CustomLinkedListNode(E value) {
        this.value = value;
    }

    public E getValue() {
        return this.value;
    }

    public void setNextNode(CustomLinkedListNode<E> node) {
        this.nextNode = node;
    }

    public CustomLinkedListNode<E> getNextNode() {
        return this.nextNode;
    }

    @Override
    public int compareTo(CustomLinkedListNode<E> other) {
        return this.value.compareTo(other.value);
    }

    @Override
    public String toString() {
        return this.value.toString();
    }
}