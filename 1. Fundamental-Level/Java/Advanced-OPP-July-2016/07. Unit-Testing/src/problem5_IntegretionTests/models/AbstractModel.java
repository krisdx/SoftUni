package problem5_IntegretionTests.models;

public abstract class AbstractModel {

    private String name;

    protected AbstractModel(String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }
}