package app.json.importDto;

import com.google.gson.annotations.SerializedName;

import java.io.Serializable;

public class AnomalyVictimDtoImportJson implements Serializable {

    @SerializedName(value = "id")
    private Long anomalyId;

    @SerializedName(value = "person")
    private String personName;

    public AnomalyVictimDtoImportJson() {
    }

    public Long getAnomalyId() {
        return this.anomalyId;
    }

    public void setAnomalyId(Long anomalyId) {
        this.anomalyId = anomalyId;
    }

    public String getPersonName() {
        return this.personName;
    }

    public void setPersonName(String personName) {
        this.personName = personName;
    }
}