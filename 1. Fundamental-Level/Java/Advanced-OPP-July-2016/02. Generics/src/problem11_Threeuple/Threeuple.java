package problem11_Threeuple;

public class Threeuple<A, B, C> {
    private A firstValue;
    private B secondValue;
    private C thirdValue;

    public Threeuple(A firstValue, B secondValue, C thirdValue) {
        this.firstValue = firstValue;
        this.secondValue = secondValue;
        this.thirdValue = thirdValue;
    }

    @Override
    public String toString() {
        return String.format("%s -> %s -> %s",
                this.firstValue, this.secondValue, this.thirdValue);
    }
}