package problem3_Ferrari;

public class Ferrari implements Car {
    private static final String FERRARI_MODEL = "488-Spider";

    private String driverName;

    public Ferrari(String driverName) {
        this.driverName = driverName;
    }

    @Override
    public String useBrakes() {
        return "Brakes!";
    }

    @Override
    public String pushGas() {
        return "Zadu6avam sA!";
    }

    @Override
    public String toString() {
        return FERRARI_MODEL  + "/"+
                this.useBrakes() + "/"+
                this.pushGas() + "/" +
                this.driverName;
    }
}