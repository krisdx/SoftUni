package problem8_CardGame;

public class CardInfo implements Comparable<CardInfo> {
    private CardRank cardRank;
    private CardSuit cardSuit;

    public CardInfo(CardRank cardRank, CardSuit cardSuit) {
        this.cardRank = cardRank;
        this.cardSuit = cardSuit;
    }

    @Override
    public int hashCode() {
        return this.cardRank.name().hashCode() + this.cardSuit.name().hashCode();
    }

    @Override
    public boolean equals(Object obj) {
        CardInfo otherCard = (CardInfo) obj;
        if (otherCard == null) {
            return false;
        }

        return this.cardRank.name().equals(otherCard.cardRank.name()) &&
                this.cardSuit.name().equals(otherCard.cardSuit.name());
    }

    @Override
    public String toString() {
        return String.format("%s of %s",
                this.cardRank.name(), this.cardSuit.name());
    }

    public int getCardPower() {
        return this.cardRank.getPower() + this.cardSuit.getPower();
    }

    @Override
    public int compareTo(CardInfo otherCard) {
        return Integer.compare(this.getCardPower(), otherCard.getCardPower());
    }
}