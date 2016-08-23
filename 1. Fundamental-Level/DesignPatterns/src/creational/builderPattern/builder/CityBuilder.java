package creational.builderPattern.builder;

import creational.builderPattern.models.City;

public interface CityBuilder {

	void setNeighborhoods();
	
	void setSupermarkets();
	
	void setHospitals();
	
	void setSchools();
	
	void setUniversities();
	
	void setPoliceStations();
	
	City getCity();
	
	void setCity(City city);
}