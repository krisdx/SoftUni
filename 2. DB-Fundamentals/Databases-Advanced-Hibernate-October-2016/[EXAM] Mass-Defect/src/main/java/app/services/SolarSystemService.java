package app.services;

import app.json.importDto.SolarSystemDtoImportJson;

public interface SolarSystemService {
    void create(SolarSystemDtoImportJson solarSystemDtoImportJson);
}