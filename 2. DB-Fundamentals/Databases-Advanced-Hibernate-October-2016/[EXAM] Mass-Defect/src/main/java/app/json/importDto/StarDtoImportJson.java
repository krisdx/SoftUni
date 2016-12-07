package app.json.importDto;

import com.google.gson.annotations.SerializedName;

import java.io.Serializable;

public class StarDtoImportJson implements Serializable {

    private String name;

    @SerializedName(value = "solarSystem")
    private String solarSystemName;

    public StarDtoImportJson() {
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSolarSystem() {
        return this.solarSystemName;
    }

    public void setSolarSystem(String solarSystemName) {
        this.solarSystemName = solarSystemName;
    }
}