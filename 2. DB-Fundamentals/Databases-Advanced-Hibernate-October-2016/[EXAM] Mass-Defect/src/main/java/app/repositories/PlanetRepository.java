package app.repositories;

import app.models.Planet;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface PlanetRepository extends JpaRepository<Planet, Long> {

    @Query(value = "SELECT p FROM Planet AS p" +
            " WHERE p.id NOT IN (SELECT a.originPlanet FROM Anomaly AS a)")
    List<Planet> findPlanetsWithoutAnomaly();

    Planet findByName(String name);
}