package problem5_ExtendedKingGambit.observers;

import problem5_ExtendedKingGambit.contracts.Attackable;

public class King implements Attackable {

    private String name;

    public King(String name) {
        this.setName(name);
    }

    public String getName() {
        return name;
    }

    private void setName(String name) {
        this.name = name;
    }

     @Override
    public void respondToAttack() {
        System.out.printf("King %s is under attack!%n",
                this.getName());
    }
}