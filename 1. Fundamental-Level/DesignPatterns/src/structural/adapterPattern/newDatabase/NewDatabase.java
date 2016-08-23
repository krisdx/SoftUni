package structural.adapterPattern.newDatabase;

import java.util.ArrayList;
import java.util.List;

import structural.adapterPattern.oldDatabase.OldDatabase;

public class NewDatabase implements Database {

	private OldDatabase oldDatabase;

	public NewDatabase() {
		this.oldDatabase = new OldDatabase();
	}

	@Override
	public void add(String name) {
		this.oldDatabase.add(name);
	}

	@Override
	public void remove(String name) {
		this.oldDatabase.getNames().remove(name);
	}

	@Override
	public void printNames() {
		for (String name : this.oldDatabase.getNames()) {
			System.out.println("- " + name);
		}
	}
}