package problem6_MirrorImage.wizards;

import problem6_MirrorImage.constracts.Wizard;
import problem6_MirrorImage.events.CastFireballSpellEvent;
import problem6_MirrorImage.events.CastReflectionEvent;

public class WizardImpl implements Wizard {

    private int id;
    private String name;
    private int magicPower;

    public WizardImpl(String name, int magicPower) {
        this.name = name;
        this.magicPower = magicPower;
    }

    public WizardImpl(int id, String name, int magicPower) {
        this(name, magicPower);
        this.id = id;
    }

    @Override
    public int getId() {
        return this.id;
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public int getMagicalPower() {
        return this.magicPower;
    }

    @Override
    public void castReflection(CastReflectionEvent reflectionSpellEvent) {
        System.out.printf("%s %d casts Reflection%n",
                this.getName(), this.getId());
    }

    @Override
    public void castFireball(CastFireballSpellEvent fireballSpellEvent) {
        System.out.printf("%s %d casts Fireball for %d damage%n",
                this.getName(), this.getId(), this.getMagicalPower());
    }

    @Override
    public String toString() {
        return Integer.toString(this.id);
    }
}