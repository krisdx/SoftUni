package problem2_GenericIntegerBox;

public class GenericIntegerBox<T> {
    private T value;

    public GenericIntegerBox(T value) {
        this.value = value;
    }

    public String getValueType() {
        return this.value.getClass().getName();
    }

    @Override
    public String toString() {
        return this.value.toString();
    }
}