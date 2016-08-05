package problem8_CardGame;

import java.util.*;

public class Main {

    private static final int NUMBER_OF_CARDS_IN_HAND = 5;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Set<CardInfo> drawnCards = new HashSet<>();
        List<CardInfo> firstPlayerCards = new ArrayList<>(NUMBER_OF_CARDS_IN_HAND);
        List<CardInfo> secondPlayerCards = new ArrayList<>(NUMBER_OF_CARDS_IN_HAND);

        String firstPlayerName = scanner.nextLine();
        String secondPlayerName = scanner.nextLine();
        while (firstPlayerCards.size() < NUMBER_OF_CARDS_IN_HAND ||
                secondPlayerCards.size() < NUMBER_OF_CARDS_IN_HAND) {

            String[] lineArgs = scanner.nextLine().split("\\s+");
            String rank = lineArgs[0];
            String suit = lineArgs[2];

            CardInfo card = null;
            try {
                CardRank cardRank = CardRank.valueOf(rank);
                CardSuit cardSuit = CardSuit.valueOf(suit);

                card = new CardInfo(cardRank, cardSuit);
            } catch (IllegalArgumentException ex) {
                System.out.println("No such card exists.");
                continue;
            }

            if (drawnCards.contains(card)) {
                System.out.println("Card is not in the deck.");
                continue;
            }

            if (firstPlayerCards.size() < 5) {
                firstPlayerCards.add(card);
            } else if (secondPlayerCards.size() < 5) {
                secondPlayerCards.add(card);
            }
            drawnCards.add(card);
        }

        boolean firstPlayerWins = false;
        CardInfo strongestCard = firstPlayerCards.get(0);
        for (int i = 1; i < firstPlayerCards.size(); i++) {
            if (firstPlayerCards.get(i).compareTo(strongestCard) > 0) {
                strongestCard = firstPlayerCards.get(i);
                firstPlayerWins = true;
            }
        }

        for (CardInfo card : secondPlayerCards) {
            if (card.compareTo(strongestCard) > 0) {
                strongestCard = card;
                firstPlayerWins = false;
            }
        }

        if (firstPlayerWins) {
            System.out.printf("%s wins with %s.%n", firstPlayerName, strongestCard);
        } else {
            System.out.printf("%s wins with %s.%n", secondPlayerName, strongestCard);

        }
    }
}