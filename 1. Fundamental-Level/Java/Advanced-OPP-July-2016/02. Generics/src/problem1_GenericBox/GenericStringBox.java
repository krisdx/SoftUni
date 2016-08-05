package problem1_GenericBox;

public class GenericStringBox<T> {
    private T value;

    public GenericStringBox(T value) {
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