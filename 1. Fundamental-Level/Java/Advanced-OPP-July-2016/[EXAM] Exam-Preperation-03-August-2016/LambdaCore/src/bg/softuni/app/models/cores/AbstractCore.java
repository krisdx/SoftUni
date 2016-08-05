package bg.softuni.app.models.cores;

import bg.softuni.app.collection.LStack;
import bg.softuni.app.collection.LinkedStack;
import bg.softuni.app.models.fragments.Fragment;
import bg.softuni.app.utility.Constants;
import bg.softuni.app.utility.Messages;

public abstract class AbstractCore implements Core {

    private static Character currentLetter =
            Constants.CORE_START_LETTER;

    private Character name;
    private long durability;
    private long maxDurability;
    private LinkedStack<Fragment> fragments;

    protected AbstractCore(long durability) {
        this.name = currentLetter;
        this.incrementLetter();
        this.durability = durability;
        this.maxDurability = durability;
        this.fragments = new LStack<>();
    }

    @Override
    public Character getName() {
        return this.name;
    }

    @Override
    public long getDurability() {
        return this.durability;
    }

    @Override
    public void setDurability(long durability) {
        if (durability < 0) {
            throw new IllegalArgumentException(Messages.NEGATIVE_CORE_DURABILITY);
        }

        if (durability <= this.maxDurability) {
            this.durability = durability;
        }
    }

    @Override
    public int getFragmentsCount() {
        return this.fragments.getSize();
    }

    @Override
    public void attachFragment(Fragment fragment) {
        fragment.applyEffect(this);
        this.fragments.push(fragment);
    }

    @Override
    public Fragment detachFragment() {
        Fragment lastFragment = this.fragments.peek();
        lastFragment.removeEffect(this);
        return this.fragments.pop();
    }

    @Override
    public String toString() {
        return String.format(
                "Core %s:%n" +
                        "####Durability: %d%n" +
                        "State TODO",
                this.getName(),
                this.getDurability());
    }

    private void incrementLetter() {
        currentLetter++;
    }
}