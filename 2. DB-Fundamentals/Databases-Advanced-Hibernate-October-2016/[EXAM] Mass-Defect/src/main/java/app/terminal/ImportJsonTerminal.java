package app.terminal;

import app.json.JsonParser;
import app.json.importDto.*;
import app.models.Person;
import app.models.Planet;
import app.models.Star;
import app.services.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

@Component
public class ImportJsonTerminal implements CommandLineRunner {

    private static final String NEW_LINE = System.lineSeparator();
    private static final String ERROR_MESSAGE = "Error: Invalid data." + NEW_LINE;
    private static final String SUCCESS_MESSAGE = "Successfully imported %s %s." + NEW_LINE;

    @Autowired
    private JsonParser jsonParser;

    @Autowired
    private SolarSystemService solarSystemService;

    @Autowired
    private StarService starService;

    @Autowired
    private PlanetService planetService;

    @Autowired
    private PersonService personService;

    @Autowired
    private AnomalyService anomalyService;

    @Override
    public void run(String... strings) throws Exception {
        this.importSolarSystems();
        this.importStars();
        this.importPlanets();
        this.importPersons();
        this.importAnomalies();
        this.importAnomaliesVictims();
    }

    private void importAnomaliesVictims() {
        AnomalyVictimDtoImportJson[] anomaliesVictimsDtos = this.jsonParser.readFromJson(AnomalyVictimDtoImportJson[].class,
                "src/main/resources/files/input/json/anomaly-victims.json");
        for (AnomalyVictimDtoImportJson anomalyVictimDto : anomaliesVictimsDtos) {
            try {
                this.anomalyService.create(anomalyVictimDto);
            } catch (Exception ex) {
                System.out.println(ERROR_MESSAGE);
            }
        }
    }

    private void importAnomalies() {
        AnomalyDtoImportJson[] anomalyDtos = this.jsonParser.readFromJson(AnomalyDtoImportJson[].class,
                "src/main/resources/files/input/json/anomalies.json");

        StringBuilder output = new StringBuilder();
        for (AnomalyDtoImportJson anomalyDto : anomalyDtos) {
            try {
                this.anomalyService.create(anomalyDto);
                output.append("Successfully imported Anomaly.").append(NEW_LINE);
            } catch (Exception ex) {
                output.append(ERROR_MESSAGE);
            }
        }

        System.out.println(output.toString().trim());
    }

    private void importPersons() {
        PersonDtoImportJson[] personDtos = this.jsonParser.readFromJson(PersonDtoImportJson[].class,
                "src/main/resources/files/input/json/persons.json");

        StringBuilder output = new StringBuilder();
        for (PersonDtoImportJson personDto : personDtos) {
            try {
                this.personService.create(personDto);
                output.append(String.format(SUCCESS_MESSAGE, Person.class.getSimpleName(), personDto.getName()));
            } catch (Exception ex) {
                output.append(ERROR_MESSAGE);
            }
        }

        System.out.println(output.toString().trim());
    }

    private void importPlanets() {
        PlanetDtoImportJson[] planetDtos = this.jsonParser.readFromJson(PlanetDtoImportJson[].class,
                "src/main/resources/files/input/json/planets.json");

        StringBuilder output = new StringBuilder();
        for (PlanetDtoImportJson planetDto : planetDtos) {
            try {
                this.planetService.create(planetDto);
                output.append(String.format(SUCCESS_MESSAGE, Planet.class.getSimpleName(), planetDto.getName()));
            } catch (Exception ex) {
                output.append(ERROR_MESSAGE);
            }
        }

        System.out.println(output.toString().trim());
    }

    private void importStars() {
        StarDtoImportJson[] starDtos = this.jsonParser.readFromJson(StarDtoImportJson[].class,
                "src/main/resources/files/input/json/stars.json");

        StringBuilder output = new StringBuilder();
        for (StarDtoImportJson starDto : starDtos) {
            try {
                this.starService.create(starDto);
                output.append(String.format(SUCCESS_MESSAGE, Star.class.getSimpleName(), starDto.getName()));
            } catch (Exception ex) {
                output.append(ERROR_MESSAGE);
            }
        }

        System.out.println(output.toString().trim());
    }

    private void importSolarSystems() {
        SolarSystemDtoImportJson[] solarSystemDtos = this.jsonParser.readFromJson(SolarSystemDtoImportJson[].class,
                "src/main/resources/files/input/json/solar-systems.json");

        StringBuilder output = new StringBuilder();
        for (SolarSystemDtoImportJson solarSystemDto : solarSystemDtos) {
            try {
                this.solarSystemService.create(solarSystemDto);
                output.append(String.format(SUCCESS_MESSAGE, "Solar System", solarSystemDto.getName()));
            } catch (Exception ex) {
                output.append(ERROR_MESSAGE);
            }
        }

        System.out.println(output.toString().trim());
    }
}