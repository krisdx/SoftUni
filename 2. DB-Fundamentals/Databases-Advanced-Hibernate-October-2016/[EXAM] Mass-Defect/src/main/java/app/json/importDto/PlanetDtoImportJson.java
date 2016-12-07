package app.json.importDto;

import java.io.Serializable;

public class PlanetDtoImportJson implements Serializable {

    private String name;
    private String sun;
    private String solarSystem;

    public PlanetDtoImportJson() {
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSun() {
        return this.sun;
    }

    public void setSun(String sun) {
        this.sun = sun;
    }

    public String getSolarSystem() {
        return this.solarSystem;
    }

    public void setSolarSystem(String solarSystem) {
        this.solarSystem = solarSystem;
    }
}