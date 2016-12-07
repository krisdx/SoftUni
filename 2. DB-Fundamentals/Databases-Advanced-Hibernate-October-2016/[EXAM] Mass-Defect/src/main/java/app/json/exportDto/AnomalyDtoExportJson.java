package app.json.exportDto;

import java.io.Serializable;

public class AnomalyDtoExportJson implements Serializable {

    private Long id;
    private PlanetDtoExportJson originPlanet;
    private PlanetDtoExportJson teleportPlanet;
    private int victimsCount;

    public AnomalyDtoExportJson() {
    }

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public PlanetDtoExportJson getOriginPlanet() {
        return this.originPlanet;
    }

    public void setOriginPlanet(PlanetDtoExportJson originPlanet) {
        this.originPlanet = originPlanet;
    }

    public PlanetDtoExportJson getTeleportPlanet() {
        return this.teleportPlanet;
    }

    public void setTeleportPlanet(PlanetDtoExportJson teleportPlanet) {
        this.teleportPlanet = teleportPlanet;
    }

    public int getVictimsCount() {
        return this.victimsCount;
    }

    public void setVictimsCount(int victimsCount) {
        this.victimsCount = victimsCount;
    }
}