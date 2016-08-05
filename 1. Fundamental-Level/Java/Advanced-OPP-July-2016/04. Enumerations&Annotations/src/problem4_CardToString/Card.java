package problem4_CardToString;

public class Card {

    private String rank;
    private String suit;

    private int rankPower;
    private int suitPower;

    public Card(String rank, String suit, int rankPower, int suitPower) {
        this.rank = rank;
        this.suit = suit;
        this.rankPower = rankPower;
        this.suitPower = suitPower;
    }

    @Override
    public String toString() {
        return String.format("Card name: %s of %s; Card power: %d",
                this.rank, this.suit, this.rankPower + this.suitPower);
    }
}