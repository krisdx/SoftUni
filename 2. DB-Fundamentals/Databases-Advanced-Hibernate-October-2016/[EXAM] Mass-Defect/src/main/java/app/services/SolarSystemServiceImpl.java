package app.services;

import app.json.importDto.SolarSystemDtoImportJson;
import app.modelParser.ModelParser;
import app.models.SolarSystem;
import app.repositories.SolarSystemRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class SolarSystemServiceImpl implements SolarSystemService {

    @Autowired
    private ModelParser modelParser;

    @Autowired
    private SolarSystemRepository solarSystemRepository;

    @Override
    public void create(SolarSystemDtoImportJson solarSystemDtoImportJson) {
        SolarSystem solarSystem =
                this.modelParser.convert(solarSystemDtoImportJson, SolarSystem.class);
        this.solarSystemRepository.save(solarSystem);
    }
}