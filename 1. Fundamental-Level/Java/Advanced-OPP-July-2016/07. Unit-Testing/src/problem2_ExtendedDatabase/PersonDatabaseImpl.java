package problem2_ExtendedDatabase;

import javax.naming.OperationNotSupportedException;
import java.util.*;

public class PersonDatabaseImpl implements PersonDatabase {

    private Map<Long, Person> personsById;
    private Map<String, Person> personsByUsername;

    public PersonDatabaseImpl() {
        this.personsById = new LinkedHashMap<>();
        this.personsByUsername = new LinkedHashMap<>();
    }

    @Override
    public void add(Person person)
            throws OperationNotSupportedException {

        if (person == null) {
            throw new OperationNotSupportedException(
                    "The person cannot be null.");
        }

        if (person.getId() == null) {
            throw new OperationNotSupportedException(
                    "The person's id cannot be null.");
        }

        if (person.getId() < 0) {
            throw new OperationNotSupportedException(
                    "The id cannot be negative.");
        }

        if (this.personsById.containsKey(person.getId())) {
            throw new OperationNotSupportedException(
                    "Person with such id already exists.");
        }

        if (this.personsByUsername.containsKey(person.getUsername())) {
            throw new OperationNotSupportedException(
                    "Person with such username already exists.");
        }

        this.personsById.put(person.getId(), person);
        this.personsByUsername.put(person.getUsername(), person);
    }

    @Override
    public Person removeById(Long id)
            throws OperationNotSupportedException {

        if (id == null) {
            throw new OperationNotSupportedException(
                    "The id cannot be null.");
        }


        if (!this.personsById.containsKey(id)) {
            throw new OperationNotSupportedException(
                    "Person with such id does not exist.");
        }

        Person personToRemove = this.personsById.get(id);

        this.personsById.remove(id);
        this.personsByUsername.remove(personToRemove.getUsername());

        return personToRemove;
    }

    @Override
    public Person removeByUsername(String username)
            throws OperationNotSupportedException {

        if (username == null || username.isEmpty()) {
            throw new OperationNotSupportedException(
                    "The username cannot be null.");
        }

        if (!this.personsByUsername.containsKey(username)) {
            throw new OperationNotSupportedException(
                    "Person with such username does not exists.");
        }

        Person personToRemove = this.personsByUsername.get(username);

        this.personsByUsername.remove(username);
        this.personsById.remove(personToRemove.getId());

        return personToRemove;
    }

    @Override
    public Person findById(Long id)
            throws OperationNotSupportedException {

        if (id == null) {
            throw new OperationNotSupportedException(
                    "The id cannot be null.");
        }

        if (!this.personsById.containsKey(id)) {
            throw new OperationNotSupportedException(
                    "Person with such id does not exist.");
        }

        return this.personsById.get(id);
    }
}