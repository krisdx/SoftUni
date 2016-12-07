package app.services;

import app.json.exportDto.PersonDtoExportJson;
import app.json.importDto.PersonDtoImportJson;

import java.util.List;

public interface PersonService {
    void create(PersonDtoImportJson personDtoImportJson);

    List<PersonDtoExportJson> findPersonsWitchHaveNotBeenVictims();
}