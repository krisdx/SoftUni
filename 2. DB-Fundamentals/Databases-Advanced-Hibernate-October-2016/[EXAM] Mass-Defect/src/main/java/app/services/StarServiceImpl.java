package app.services;

import app.json.importDto.StarDtoImportJson;
import app.modelParser.ModelParser;
import app.models.SolarSystem;
import app.models.Star;
import app.repositories.SolarSystemRepository;
import app.repositories.StarRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class StarServiceImpl implements StarService {

    @Autowired
    private ModelParser modelParser;

    @Autowired
    private SolarSystemRepository solarSystemRepository;

    @Autowired
    private StarRepository starRepository;

    @Override
    public void create(StarDtoImportJson starDtoImportJson) {
        Star star = this.modelParser.convert(starDtoImportJson, Star.class);
        SolarSystem solarSystem =
                this.solarSystemRepository.findByName(starDtoImportJson.getSolarSystem());
        star.setSolarSystem(solarSystem);

        this.starRepository.saveAndFlush(star);
    }
}