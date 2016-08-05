package bg.softuni.app.data;

import bg.softuni.app.models.cores.Core;
import bg.softuni.app.models.fragments.Fragment;
import bg.softuni.app.utility.Messages;

import java.util.LinkedHashMap;
import java.util.Map;

public class LambdaCoreDatabase implements DataProvider {

    private Core currentCore;
    private Map<Character, Core> cores;

    public LambdaCoreDatabase() {
        this.currentCore = null;
        this.cores = new LinkedHashMap<>();
    }

    @Override
    public Core getCurrentCore() {
        return this.currentCore;
    }

    @Override
    public void addCore(Core core) {
        this.cores.put(core.getName(), core);
    }

    @Override
    public void removeCore(Character coreName) {
        this.validateExitingCore(coreName);

        this.cores.remove(coreName);
    }

    @Override
    public void selectCore(Character coreName) {
        this.validateExitingCore(coreName);

        this.currentCore = this.cores.get(coreName);
    }

    @Override
    public void attachFragment(Fragment fragment) {
        this.validateSelectedCore();

        this.currentCore.attachFragment(fragment);
    }

    @Override
    public Fragment detachFragment() {
        this.validateSelectedCore();

        return this.currentCore.detachFragment();
    }

    @Override
    public String status() {
        StringBuilder status = new StringBuilder();

        status.append("Lambda Core Power Plant Status:")
                .append(System.lineSeparator());

        status.append("Total Durability: ").append(this.getTotalDurability())
                .append(System.lineSeparator());
        status.append("Total Cores: ").append(this.cores.size())
                .append(System.lineSeparator());
        status.append("Total Fragments: ").append(this.getTotalFragmentsCount())
                .append(System.lineSeparator());

        for (Core core : cores.values()) {
            status.append(core.toString())
                    .append(System.lineSeparator());
        }

        return status.toString().trim();
    }

    private void validateExitingCore(Character coreName) {
        if (!this.cores.containsKey(coreName)) {
            throw new UnsupportedOperationException(
                    String.format(Messages.NON_EXISTING_CORE_IN_DATABASE, coreName));
        }
    }

    private void validateSelectedCore() {
        if (this.currentCore == null) {
            throw new UnsupportedOperationException(Messages.NON_SELECTED_CORE);
        }
    }

    private int getTotalFragmentsCount() {
        int totalFragmentsCount = 0;
        for (Core core : cores.values()) {
            totalFragmentsCount += core.getFragmentsCount();
        }

        return totalFragmentsCount;
    }

    private long getTotalDurability() {
        long totalDurability = 0;
        for (Core core : cores.values()) {
            totalDurability += core.getDurability();
        }

        return totalDurability;
    }
}