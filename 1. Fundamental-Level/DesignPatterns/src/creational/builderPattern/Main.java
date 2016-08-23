package creational.builderPattern;

import creational.builderPattern.builder.BurgasCityBuilder;
import creational.builderPattern.builder.CityBuilder;
import creational.builderPattern.builder.SofiaCityBuilder;
import creational.builderPattern.models.City;

public class Main {

	public static void main(String[] args) {

		/**
		 * Builder pattern Separates the construction of a complex object from
		 * its representation so that the same construction process can create
		 * different representations.
		 */

		CityConstructor constructor = new CityConstructor();

		CityBuilder sofiaCityBuilder = new SofiaCityBuilder();
		constructor.constructCity(sofiaCityBuilder);
		City sofiaCity = sofiaCityBuilder.getCity();
		System.out.println(sofiaCity);

		System.out.println();

		CityBuilder burgasCityBuilder = new BurgasCityBuilder();
		constructor.constructCity(burgasCityBuilder);
		City burgasCity = burgasCityBuilder.getCity();
		System.out.println(burgasCity);
	}
}