package app.xml.importDto;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlRootElement;
import java.io.Serializable;

@XmlRootElement(name = "victim")
@XmlAccessorType(XmlAccessType.FIELD)
public class VictimDtoImportXml implements Serializable {

    @XmlAttribute(name = "name")
    private String victimName;

    public VictimDtoImportXml() {
    }

    public String getVictimName() {
        return this.victimName;
    }

    public void setVictimName(String victimName) {
        this.victimName = victimName;
    }
}