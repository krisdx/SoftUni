package creational.builderPattern.builder;

import creational.builderPattern.models.City;

public abstract class AbstractCityBuilder implements CityBuilder {

	private City city;

	@Override
	public City getCity() {
		return this.city;
	}
	
	@Override
	public void setCity(City city) {
		this.city = city;		
	}
}