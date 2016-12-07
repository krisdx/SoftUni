package app.terminal;

import app.services.AnomalyService;
import app.xml.XmlParser;
import app.xml.importDto.AnomaliesDtoImportXml;
import app.xml.importDto.AnomalyDtoImportXml;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import javax.xml.bind.JAXBException;

@Component
public class ImportXmlTerminal implements CommandLineRunner {

    private static final String NEW_LINE = System.lineSeparator();
    private static final String ERROR_MESSAGE = "Error: Invalid data." + NEW_LINE;
    private static final String SUCCESS_MESSAGE = "Successfully imported data." + NEW_LINE;

    @Autowired
    private XmlParser xmlParser;

    @Autowired
    private AnomalyService anomalyService;

    @Override
    public void run(String... strings) throws Exception {
        this.importAnomalies();
    }

    private void importAnomalies() throws JAXBException {
        AnomaliesDtoImportXml anomaliesDtos = this.xmlParser.readFromXml(AnomaliesDtoImportXml.class,
                "src/main/resources/files/input/xml/new-anomalies.xml");

        StringBuilder output = new StringBuilder();
        for (AnomalyDtoImportXml anomalyDto : anomaliesDtos.getAnomalies()) {
            try {
                this.anomalyService.create(anomalyDto);
                output.append(SUCCESS_MESSAGE);
            } catch (Exception ex) {
                System.out.println(ERROR_MESSAGE);
            }
        }

        System.out.println(output.toString().trim());
    }
}