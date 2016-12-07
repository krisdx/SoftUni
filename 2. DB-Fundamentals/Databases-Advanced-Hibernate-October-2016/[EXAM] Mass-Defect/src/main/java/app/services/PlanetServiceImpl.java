package app.services;

import app.json.exportDto.PlanetDtoExportJson;
import app.json.importDto.PlanetDtoImportJson;
import app.modelParser.ModelParser;
import app.models.Planet;
import app.models.SolarSystem;
import app.models.Star;
import app.repositories.PlanetRepository;
import app.repositories.SolarSystemRepository;
import app.repositories.StarRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.List;

@Service
@Transactional
public class PlanetServiceImpl implements PlanetService {

    @Autowired
    private ModelParser modelParser;

    @Autowired
    private SolarSystemRepository solarSystemRepository;

    @Autowired
    private StarRepository starRepository;

    @Autowired
    private PlanetRepository planetRepository;

    @Override
    public void create(PlanetDtoImportJson planetDtoImportJson) {
        SolarSystem solarSystem =
                this.solarSystemRepository.findByName(planetDtoImportJson.getSolarSystem());
        Star sun = this.starRepository.findByName(planetDtoImportJson.getSun());
        Planet planet = this.modelParser.convert(planetDtoImportJson, Planet.class);
        planet.setSolarSystem(solarSystem);
        planet.setSun(sun);

        this.planetRepository.saveAndFlush(planet);
    }

    @Override
    public List<PlanetDtoExportJson> findPlanetsWithoutAnomaly() {
        List<Planet> planetsWithoutAnomaly =
                this.planetRepository.findPlanetsWithoutAnomaly();
        List<PlanetDtoExportJson> planetDtos = new ArrayList<>();
        for (Planet planet : planetsWithoutAnomaly) {
            PlanetDtoExportJson planetDto =
                    this.modelParser.convert(planet, PlanetDtoExportJson.class);
            planetDtos.add(planetDto);
        }

        return planetDtos;
    }
}