package app.json.importDto;

import com.google.gson.annotations.SerializedName;

import java.io.Serializable;

public class SolarSystemDtoImportJson implements Serializable {

    @SerializedName(value = "name")
    private String solarSystemName;

    public SolarSystemDtoImportJson() {
    }

    public String getName() {
        return this.solarSystemName;
    }

    public void setName(String solarSystemName) {
        this.solarSystemName = solarSystemName;
    }
}