package problem10_Mood3;

public class Demon<T> extends AbstractHero<T> {
    public Demon(String username, int level, T specialPoints) {
        super(username, level, specialPoints);
    }

    @Override
    public String getHashedPassword() {
        return null;
    }
}
