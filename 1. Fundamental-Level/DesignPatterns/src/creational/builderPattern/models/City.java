package creational.builderPattern.models;

import java.util.List;

public class City {

	private String name;

	private List<String> neighborhoods;
	private List<String> supermarkets;
	private List<String> hospitals;
	private List<String> schools;
	private List<String> universities;
	private List<String> policeStations;

	public City(String name) {
		this.name = name;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public List<String> getNeighborhoods() {
		return this.neighborhoods;
	}

	public void setNeighborhoods(List<String> neighborhoods) {
		this.neighborhoods = neighborhoods;
	}

	public List<String> getSetSupermarkets() {
		return this.supermarkets;
	}

	public void setSupermarkets(List<String> setSupermarkets) {
		this.supermarkets = setSupermarkets;
	}

	public List<String> getHospitals() {
		return this.hospitals;
	}

	public void setHospitals(List<String> setHospitals) {
		this.hospitals = setHospitals;
	}

	public List<String> getSetSchools() {
		return this.schools;
	}

	public void setSchools(List<String> setSchools) {
		this.schools = setSchools;
	}

	public List<String> getUniversities() {
		return this.universities;
	}

	public void setUniversities(List<String> setUniversities) {
		this.universities = setUniversities;
	}

	public List<String> getPoliceStations() {
		return this.policeStations;
	}

	public void setPoliceStations(List<String> setPoliceStations) {
		this.policeStations = setPoliceStations;
	}

	@Override
	public String toString() {
		StringBuilder output = new StringBuilder();

		output.append("City Name: ").append(this.name).append(System.lineSeparator());

		output.append("Neighborhoods: ").append(System.lineSeparator());
		append(output, this.neighborhoods);

		output.append("Supermarkets: ").append(System.lineSeparator());
		append(output, this.supermarkets);

		output.append("Hospitals: ").append(System.lineSeparator());
		append(output, this.hospitals);

		output.append("Schools: ").append(System.lineSeparator());
		append(output, this.schools);

		output.append("Universities: ").append(System.lineSeparator());
		append(output, this.universities);

		output.append("PoliceStations: ").append(System.lineSeparator());
		append(output, this.policeStations);

		return output.toString();
	}

	private void append(StringBuilder output, List<String> toAppend) {
		for (String str : toAppend) {
			output.append("- ").append(str).append(System.lineSeparator());
		}
	}
}