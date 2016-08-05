package bg.softuni.app.core.io.command;

public abstract class Command implements Executable {

    private String[] data;

    protected Command(String[] data){
        this.data = data;
    }

    protected String[] getData() {
        return this.data;
    }
}