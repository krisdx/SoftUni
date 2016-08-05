package problem10_Mood3;

public abstract class AbstractHero<T> implements Hero<T> {

    private String username;
    private int level;
    private T specialPoints;

    protected String hashedPassword;

    protected AbstractHero(String username, int level, T specialPoints) {
        this.username = username;
        this.level = level;
        this.specialPoints = specialPoints;
    }

    @Override
    public String getUsername() {
        return this.username;
    }

    @Override
    public int getLevel() {
        return this.level;
    }

    @Override
    public T getSpecialPoints() {
        return this.specialPoints;
    }
}