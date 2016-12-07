package app.xml.importDto;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

@XmlRootElement(name = "anomalies")
@XmlAccessorType(XmlAccessType.FIELD)
public class AnomaliesDtoImportXml implements Serializable {

    @XmlElement(name = "anomaly")
    private List<AnomalyDtoImportXml> anomalies;

    public AnomaliesDtoImportXml() {
        this.setAnomalies(new ArrayList<>());
    }

    public List<AnomalyDtoImportXml> getAnomalies() {
        return this.anomalies;
    }

    public void setAnomalies(List<AnomalyDtoImportXml> anomalies) {
        this.anomalies = anomalies;
    }
}