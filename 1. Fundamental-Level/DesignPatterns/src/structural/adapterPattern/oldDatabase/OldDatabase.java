package structural.adapterPattern.oldDatabase;

import java.util.ArrayList;
import java.util.List;

public class OldDatabase {

	private List<String> names;

	public OldDatabase() {
		this.names = new ArrayList<>();
	}

	public void add(String name) {
		this.names.add(name);
	}

	public List<String> getNames() {
		return this.names;
	}
}