package app.terminal;

import app.json.JsonParser;
import app.json.exportDto.AnomalyDtoExportJson;
import app.json.exportDto.PersonDtoExportJson;
import app.json.exportDto.PlanetDtoExportJson;
import app.services.AnomalyService;
import app.services.PersonService;
import app.services.PlanetService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.io.IOException;
import java.util.List;

@Component
public class ExportJsonTerminal implements CommandLineRunner {

    @Autowired
    private JsonParser jsonParser;

    @Autowired
    private PlanetService planetService;

    @Autowired
    private PersonService personService;

    @Autowired
    private AnomalyService anomalyService;

    @Override
    public void run(String... strings) throws Exception {
        this.writePlanetsWithoutAnomalies();
        this.writePersonsWitchHaveNotBeenVictim();
        this.writeAnomalyWithMostVictims();
    }

    private void writeAnomalyWithMostVictims() throws IOException {
        AnomalyDtoExportJson anomalyDto =
                this.anomalyService.getAnomalyWithMostVictims();

        this.jsonParser.writeToJson(anomalyDto,
                "src/main/resources/files/output/json/anomaly.json");
    }

    private void writePersonsWitchHaveNotBeenVictim() throws IOException {
        List<PersonDtoExportJson> personDtos =
                this.personService.findPersonsWitchHaveNotBeenVictims();

        this.jsonParser.writeToJson(personDtos,
                "src/main/resources/files/output/json/persons.json");
    }

    private void writePlanetsWithoutAnomalies() throws IOException {
        List<PlanetDtoExportJson> planetDtos =
                this.planetService.findPlanetsWithoutAnomaly();

        this.jsonParser.writeToJson(planetDtos,
                "src/main/resources/files/output/json/planets.json");
    }
}