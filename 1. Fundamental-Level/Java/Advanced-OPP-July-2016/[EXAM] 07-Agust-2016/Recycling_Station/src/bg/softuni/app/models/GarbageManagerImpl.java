package bg.softuni.app.models;

import bg.softuni.app.framework.contracts.GarbageManager;
import com.sun.deploy.security.ValidationState;

public class GarbageManagerImpl implements GarbageManager {

    private static final String DEFAULT_TYPE = "";

    private String deniedType;
    private double energy;
    private double capital;

    public GarbageManagerImpl() {
        this.deniedType = DEFAULT_TYPE;
    }

    @Override
    public void setManagement(String type, double energy, double capital) {
        this.deniedType = type;
        this.capital = capital;
        this.energy = energy;
    }

    @Override
    public boolean canProduce(String type, double currentEnergy, double currentCapital) {
        if (this.deniedType.equals(type)){
            return false;
        }

        if (currentEnergy < this.energy && currentCapital < this.capital) {
            return false;
        }

        return true;
    }
}