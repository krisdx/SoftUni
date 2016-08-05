package problem3_4_5_BarrackWars.models.units;

public class Archer extends AbstractUnit {

    private static final int ARCHER_HEALTH = 25;
    private static final int ARCHER_DAMAGE = 7;

    public Archer() {
        super(ARCHER_HEALTH, ARCHER_DAMAGE);
    }
}