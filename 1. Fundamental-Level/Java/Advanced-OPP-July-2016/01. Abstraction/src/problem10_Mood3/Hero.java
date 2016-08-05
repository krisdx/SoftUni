package problem10_Mood3;

public interface Hero<T> {

    String getUsername();

    String getHashedPassword();

    int getLevel ();

    T getSpecialPoints();
}