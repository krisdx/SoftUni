package app.json.importDto;

import com.google.gson.annotations.SerializedName;

import java.io.Serializable;

public class AnomalyDtoImportJson implements Serializable {

    @SerializedName(value = "originPlanet")
    private String originPlanetName;

    @SerializedName(value = "teleportPlanet")
    private String teleportPlanetName;

    public AnomalyDtoImportJson() {
    }

    public String getOriginPlanet() {
        return this.originPlanetName;
    }

    public void setOriginPlanet(String originPlanetName) {
        this.originPlanetName = originPlanetName;
    }

    public String getTeleportPlanet() {
        return this.teleportPlanetName;
    }

    public void setTeleportPlanet(String teleportPlanetName) {
        this.teleportPlanetName = teleportPlanetName;
    }
}