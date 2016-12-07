package app.json.exportDto;

import java.io.Serializable;

public class PlanetDtoExportJson implements Serializable {

    private String name;

    public PlanetDtoExportJson() {
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
