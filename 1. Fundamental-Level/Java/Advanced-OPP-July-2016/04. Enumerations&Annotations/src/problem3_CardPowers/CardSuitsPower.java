package problem3_CardPowers;

public enum CardSuitsPower {
    CLUBS(0),
    DIAMONDS(13),
    HEARTS(26),
    SPADES(39);

    private int power;

    private CardSuitsPower(int power) {
        this.power = power;
    }

    public int getPower() {
        return this.power;
    }
}
