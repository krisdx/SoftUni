package problem6_CustomEnumAnnotation;

@CustomEnumAnnotation(
        type = "Enumeration",
        category = "Suit",
        description = "Provides suit constants for a Card class.")
public enum Suit {
    CLUBS,
    DIAMONDS,
    HEARTS,
    SPADES
}