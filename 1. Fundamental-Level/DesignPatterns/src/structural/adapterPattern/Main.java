package structural.adapterPattern;

import structural.adapterPattern.newDatabase.Database;
import structural.adapterPattern.newDatabase.NewDatabase;

public class Main {

	public static void main(String[] args) {

		/**
		 * Adapter pattern convert the interface of a class into another
		 * interface clients expect. Wrap an existing class with a new
		 * interface. Matches an old component to a new system.
		 */

		Database database = new NewDatabase();

		String[] names = new String[] { "Pesho", "Gosho", "Kiro", "Mariq" };
		for (int i = 0; i < names.length; i++) {
			database.add(names[i]);
		}

		printNames(database);

		for (int i = 0; i < names.length; i++) {
			database.remove(names[i]);
		}

		printNames(database);
	}

	private static void printNames(Database database) {
		System.out.println("Print all names in database:");
		database.printNames();
	}
}