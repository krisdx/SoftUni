package app.services;

import app.json.importDto.StarDtoImportJson;

public interface StarService {
    void create(StarDtoImportJson starDtoImportJson);
}