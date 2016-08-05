package problem5_CardCompareTo;

public enum CardRankPower {

    TWO(2),
    THREE(3),
    FOUR(4),
    FIVE(5),
    SIX(6),
    SEVEN(7),
    EIGHT(8),
    NINE(9),
    TEN(10),
    JACK(11),
    QUEEN(12),
    KING(13),
    ACE(14);

    private int power;

    private CardRankPower(int power) {
        this.power = power;
    }

    public int getPower() {
        return this.power;
    }
}