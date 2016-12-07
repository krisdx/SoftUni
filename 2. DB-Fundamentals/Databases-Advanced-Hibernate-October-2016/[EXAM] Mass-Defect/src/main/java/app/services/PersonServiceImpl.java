package app.services;

import app.json.exportDto.PersonDtoExportJson;
import app.json.importDto.PersonDtoImportJson;
import app.modelParser.ModelParser;
import app.models.Person;
import app.models.Planet;
import app.repositories.PersonRepository;
import app.repositories.PlanetRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.List;

@Service
@Transactional
public class PersonServiceImpl implements PersonService {

    @Autowired
    private ModelParser modelParser;

    @Autowired
    private PersonRepository personRepository;

    @Autowired
    private PlanetRepository planetRepository;


    @Override
    public void create(PersonDtoImportJson personDtoImportJson) {
        Planet homePlanet =
                this.planetRepository.findByName(personDtoImportJson.getHomePlanet());
        Person person = this.modelParser.convert(personDtoImportJson, Person.class);
        person.setHomePlanet(homePlanet);

        this.personRepository.saveAndFlush(person);
    }

    @Override
    public List<PersonDtoExportJson> findPersonsWitchHaveNotBeenVictims() {
        List<Person> persons = this.personRepository.findPersonsWitchHaveNotBeenVictims();
        List<PersonDtoExportJson> personDtos = new ArrayList<>();
        for (Person person : persons) {
            PersonDtoExportJson personDto =
                    this.modelParser.convert(person, PersonDtoExportJson.class);
            personDtos.add(personDto);
        }

        return personDtos;
    }
}