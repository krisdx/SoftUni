package app.json.exportDto;

import java.io.Serializable;

public class PersonDtoExportJson implements Serializable {

    private String name;
    private PlanetDtoExportJson homePlanet;

    public PersonDtoExportJson() {
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public PlanetDtoExportJson getHomePlanet() {
        return this.homePlanet;
    }

    public void setHomePlanet(PlanetDtoExportJson homePlanet) {
        this.homePlanet = homePlanet;
    }
}