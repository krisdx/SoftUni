package creational.builderPattern.builder;

import java.util.Arrays;

import creational.builderPattern.models.City;

public class SofiaCityBuilder extends AbstractCityBuilder implements CityBuilder {

	private static final String SOFIA_CITY_NAME = "Sofia";

	public SofiaCityBuilder() {
		this.setCity(new City(SOFIA_CITY_NAME));
	}

	@Override
	public void setNeighborhoods() {
		String[] neighborhoods = new String[] { "Nadejda", "Mladost", "Lulin", };
		this.getCity().setNeighborhoods(Arrays.asList(neighborhoods));
	}

	@Override
	public void setSupermarkets() {
		String[] supermarkets = new String[] { "Billa", "Fantastiko", "Kaufland", "LILD" };
		this.getCity().setSupermarkets(Arrays.asList(supermarkets));
	}

	@Override
	public void setHospitals() {
		String[] hospitals = new String[] { "Pirogov", "Tokuda" };
		this.getCity().setHospitals(Arrays.asList(hospitals));
	}

	@Override
	public void setSchools() {
		String[] schools = new String[] { "Frenskata gimnaziq", "PGTK", "NPMG" };
		this.getCity().setSchools(Arrays.asList(schools));
	}

	@Override
	public void setUniversities() {
		String[] universities = new String[] { "UNSS", "TU", "SU" };
		this.getCity().setUniversities(Arrays.asList(universities));
	}

	@Override
	public void setPoliceStations() {
		String[] policeStations = new String[] { "Purvo Raionno", "Purvo Raionno" };
		this.getCity().setPoliceStations(Arrays.asList(policeStations));
	}
}