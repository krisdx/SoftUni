package problem5_CardCompareTo;

public class Card implements Comparable<Card>{

    private CardRankPower cardRankPower;
    private CardSuitsPower cardSuitsPower;

    public Card(CardRankPower cardRankPower, CardSuitsPower cardSuitsPower){
        this.cardRankPower = cardRankPower;
        this.cardSuitsPower = cardSuitsPower;
    }

    public int getCardPower(){
        return this.cardRankPower.getPower() + this.cardSuitsPower.getPower();
    }

    @Override
    public int compareTo(Card other) {
        return Integer.compare(this.getCardPower(), other.getCardPower());
    }

    @Override
    public String toString() {
        return String.format("Card name: %s of %s; Card power: %d",
                this.cardRankPower.name(),
                this.cardSuitsPower.name(),
                this.getCardPower());
    }
}