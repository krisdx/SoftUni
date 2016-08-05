package problem7_DeckOfCards;

public class Main {
    public static void main(String[] args) {
        RankEnum[] ranks = RankEnum.values();
        SuitEnum[] suits = SuitEnum.values();

        for (SuitEnum suit : suits) {
            for (RankEnum rank : ranks) {
                System.out.printf("%s of %s%n", rank, suit);
            }
        }
    }
}