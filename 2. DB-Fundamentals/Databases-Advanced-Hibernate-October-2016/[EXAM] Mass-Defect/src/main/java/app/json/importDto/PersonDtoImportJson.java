package app.json.importDto;

import com.google.gson.annotations.SerializedName;

import java.io.Serializable;

public class PersonDtoImportJson implements Serializable {

    private String name;

    @SerializedName(value = "homePlanet")
    private String homePlanetName;

    public PersonDtoImportJson() {
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getHomePlanet() {
        return this.homePlanetName;
    }

    public void setHomePlanet(String homePlanetName) {
        this.homePlanetName = homePlanetName;
    }
}