package problem6_CustomEnumAnnotation;

@CustomEnumAnnotation(
        type = "Enumeration",
        category = "RankEnum",
        description = "Provides rank constants for a Card class.")
public enum Rank {
    ACE,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX,
    SEVEN,
    EIGHT,
    NINE,
    TEN,
    JACK,
    QUEEN,
    KING
}