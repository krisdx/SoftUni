package app.services;

import app.json.exportDto.AnomalyDtoExportJson;
import app.json.importDto.AnomalyDtoImportJson;
import app.json.importDto.AnomalyVictimDtoImportJson;
import app.xml.exportDto.AnomaliesDtoExportXml;
import app.xml.importDto.AnomalyDtoImportXml;

public interface AnomalyService {
    void create(AnomalyDtoImportJson anomalyDtoImportJson);

    void create(AnomalyVictimDtoImportJson anomalyVictimDto);

    void create(AnomalyDtoImportXml anomalyDtoImportXml);

    AnomalyDtoExportJson getAnomalyWithMostVictims();

    AnomaliesDtoExportXml findAll();
}