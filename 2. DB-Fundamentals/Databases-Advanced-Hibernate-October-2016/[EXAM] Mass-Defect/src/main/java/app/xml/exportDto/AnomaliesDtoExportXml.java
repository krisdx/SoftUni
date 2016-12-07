package app.xml.exportDto;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

@XmlRootElement(name = "anomalies")
@XmlAccessorType(XmlAccessType.FIELD)
public class AnomaliesDtoExportXml implements Serializable {

    @XmlElement(name = "anomaly")
    private List<AnomalyDtoExportXml> anomalyExportDtos;

    public AnomaliesDtoExportXml() {
        this.setAnomalyExportDtos(new ArrayList<>());
    }

    public List<AnomalyDtoExportXml> getAnomalyExportDtos() {
        return this.anomalyExportDtos;
    }

    public void setAnomalyExportDtos(List<AnomalyDtoExportXml> anomalyExportDtos) {
        this.anomalyExportDtos = anomalyExportDtos;
    }

    public void add(AnomalyDtoExportXml anomalyDtoExportXml) {
        this.getAnomalyExportDtos().add(anomalyDtoExportXml);
    }
}