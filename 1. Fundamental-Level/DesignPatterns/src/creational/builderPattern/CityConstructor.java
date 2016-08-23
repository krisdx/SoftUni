package creational.builderPattern;

import creational.builderPattern.builder.CityBuilder;

public class CityConstructor {

	public void constructCity(CityBuilder cityBuilder) {
		cityBuilder.setSupermarkets();
		cityBuilder.setHospitals();
		cityBuilder.setNeighborhoods();
		cityBuilder.setSchools();
		cityBuilder.setUniversities();
		cityBuilder.setPoliceStations();
	}
}