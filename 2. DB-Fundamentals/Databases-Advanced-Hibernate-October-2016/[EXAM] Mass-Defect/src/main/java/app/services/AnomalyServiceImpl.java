package app.services;

import app.json.exportDto.AnomalyDtoExportJson;
import app.json.importDto.AnomalyDtoImportJson;
import app.json.importDto.AnomalyVictimDtoImportJson;
import app.modelParser.ModelParser;
import app.models.Anomaly;
import app.models.Person;
import app.models.Planet;
import app.repositories.AnomalyRepository;
import app.repositories.PersonRepository;
import app.repositories.PlanetRepository;
import app.xml.exportDto.AnomaliesDtoExportXml;
import app.xml.exportDto.AnomalyDtoExportXml;
import app.xml.importDto.AnomalyDtoImportXml;
import app.xml.importDto.VictimDtoImportXml;
import org.modelmapper.PropertyMap;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service
@Transactional
public class AnomalyServiceImpl implements AnomalyService {

    @Autowired
    private ModelParser modelParser;

    @Autowired
    private AnomalyRepository anomalyRepository;

    @Autowired
    private PlanetRepository planetRepository;

    @Autowired
    private PersonRepository personRepository;

    @Override
    public void create(AnomalyDtoImportJson anomalyDtoImportJson) {
        Planet originPlanet =
                this.planetRepository.findByName(anomalyDtoImportJson.getOriginPlanet());
        Planet teleportPlanet =
                this.planetRepository.findByName(anomalyDtoImportJson.getTeleportPlanet());
        Anomaly anomaly = this.modelParser.convert(anomalyDtoImportJson, Anomaly.class);
        anomaly.setOriginPlanet(originPlanet);
        anomaly.setTeleportPlanet(teleportPlanet);

        this.anomalyRepository.saveAndFlush(anomaly);
    }

    @Override
    public void create(AnomalyVictimDtoImportJson anomalyVictimDto) {
        Anomaly anomaly =
                this.anomalyRepository.findOne(anomalyVictimDto.getAnomalyId());
        Person victim =
                this.personRepository.findByName(anomalyVictimDto.getPersonName());
        anomaly.addVictim(victim);
        this.anomalyRepository.saveAndFlush(anomaly);
    }

    @Override
    public void create(AnomalyDtoImportXml anomalyDtoImportXml) {
        Planet originPlanet = this.planetRepository.findByName(anomalyDtoImportXml.getOriginPlanet());
        Planet teleportPlant = this.planetRepository.findByName(anomalyDtoImportXml.getTeleportPlanet());

        Anomaly anomaly = this.modelParser.convert(anomalyDtoImportXml, Anomaly.class);
        anomaly.setOriginPlanet(originPlanet);
        anomaly.setTeleportPlanet(teleportPlant);

        anomaly.getVictims().clear();
        for (VictimDtoImportXml victimDto : anomalyDtoImportXml.getVictims()) {
            Person victim =
                    this.personRepository.findByName(victimDto.getVictimName());
            anomaly.addVictim(victim);
        }

        this.anomalyRepository.saveAndFlush(anomaly);
    }

    @Override
    public AnomalyDtoExportJson getAnomalyWithMostVictims() {
        Anomaly anomaly = this.anomalyRepository.getAnomalyWithMostVictims();

        PropertyMap<Anomaly, AnomalyDtoExportJson> propertyMap = new PropertyMap<Anomaly, AnomalyDtoExportJson>() {
            @Override
            protected void configure() {
                map(source.getVictims().size(), destination.getVictimsCount());
            }
        };

        return this.modelParser.convert(anomaly, AnomalyDtoExportJson.class, propertyMap);
    }

    @Override
    public AnomaliesDtoExportXml findAll() {
        List<Anomaly> anomalies = this.anomalyRepository.findAll();

        AnomaliesDtoExportXml anomaliesDto = new AnomaliesDtoExportXml();
        PropertyMap<Anomaly, AnomalyDtoExportXml> propertyMap = new PropertyMap<Anomaly, AnomalyDtoExportXml>() {
            @Override
            protected void configure() {
                map(source.getOriginPlanet().getName(), destination.getOriginPlanet());
                map(source.getTeleportPlanet().getName(), destination.getTeleportPlanet());
            }
        };

        for (Anomaly anomaly : anomalies) {
            AnomalyDtoExportXml anomalyDtoExportXml =
                    this.modelParser.convert(anomaly, AnomalyDtoExportXml.class, propertyMap);
            anomaliesDto.add(anomalyDtoExportXml);
        }

        return anomaliesDto;
    }
}