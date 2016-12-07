package app.services;

import app.json.exportDto.PlanetDtoExportJson;
import app.json.importDto.PlanetDtoImportJson;

import java.util.List;

public interface PlanetService {
    void create(PlanetDtoImportJson planetDtoImportJson);

    List<PlanetDtoExportJson> findPlanetsWithoutAnomaly();
}