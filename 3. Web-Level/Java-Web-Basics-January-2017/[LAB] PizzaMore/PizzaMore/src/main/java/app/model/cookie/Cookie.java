package app.model.cookie;

public class Cookie {

    private String name;
    private String value;

    public Cookie(String name, String value) {
        this.setName(name);
        this.setValue(value);
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getValue() {
        return this.value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    public String getCookie() {
        return this.getName() + "=" + this.getValue() + "; ";
    }
}