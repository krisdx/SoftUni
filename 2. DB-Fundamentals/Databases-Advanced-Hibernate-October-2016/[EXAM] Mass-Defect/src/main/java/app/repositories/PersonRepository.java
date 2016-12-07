package app.repositories;

import app.models.Person;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface PersonRepository extends JpaRepository<Person, Long> {

    @Query(value = "SELECT * FROM persons AS p " +
            "WHERE p.id NOT IN (SELECT person_id FROM anomaly_victims)",
            nativeQuery = true)
    List<Person> findPersonsWitchHaveNotBeenVictims();

    Person findByName(String name);
}