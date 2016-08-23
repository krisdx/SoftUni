package creational.builderPattern.builder;

import java.util.Arrays;

import creational.builderPattern.models.City;

public class BurgasCityBuilder extends AbstractCityBuilder implements CityBuilder {

	private static final String BURGAS_CITY_NAME = "Burgas";

	public BurgasCityBuilder() {
		this.setCity(new City(BURGAS_CITY_NAME));
	}

	@Override
	public void setNeighborhoods() {
		String[] neighborhoods = new String[] { "Banevo", "Lozovo", "Rudnik", };
		this.getCity().setNeighborhoods(Arrays.asList(neighborhoods));
	}

	@Override
	public void setSupermarkets() {
		String[] supermarkets = new String[] { "Billa", "Fantastiko" };
		this.getCity().setSupermarkets(Arrays.asList(supermarkets));
	}

	@Override
	public void setHospitals() {
		String[] hospitals = new String[] { "Live Hospital" };
		this.getCity().setHospitals(Arrays.asList(hospitals));
	}

	@Override
	public void setSchools() {
		String[] schools = new String[] { "SOU Ivan Vazov" };
		this.getCity().setSchools(Arrays.asList(schools));
	}

	@Override
	public void setUniversities() {
		String[] universities = new String[] { "Burgas Free University"};
		this.getCity().setUniversities(Arrays.asList(universities));
	}

	@Override
	public void setPoliceStations() {
		String[] policeStations = new String[] { "Treto Raionno" };
		this.getCity().setPoliceStations(Arrays.asList(policeStations));
	}
}