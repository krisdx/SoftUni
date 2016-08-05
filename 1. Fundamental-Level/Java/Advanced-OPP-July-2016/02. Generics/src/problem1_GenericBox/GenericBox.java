package problem1_GenericBox;

public class GenericBox<T> {
    private String value;

    public GenericBox(String value) {
        this.value = value;
    }

    public String getValue() {
        return this.value;
    }

    @Override
    public String toString() {
        return this.value;
    }
}