package app.terminal;

import app.services.AnomalyService;
import app.xml.XmlParser;
import app.xml.exportDto.AnomaliesDtoExportXml;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import javax.xml.bind.JAXBException;

@Component
public class ExportXmlTerminal implements CommandLineRunner {

    @Autowired
    private AnomalyService anomalyService;

    @Autowired
    private XmlParser xmlParser;

    @Override
    public void run(String... strings) throws Exception {
        this.exportToXml();
    }

    private void exportToXml() throws JAXBException {
        AnomaliesDtoExportXml anomaliesDtoExportXml = this.anomalyService.findAll();
        this.xmlParser.writeToXml(anomaliesDtoExportXml,
                "src/main/resources/files/output/xml/anomalies.xml");
    }
}