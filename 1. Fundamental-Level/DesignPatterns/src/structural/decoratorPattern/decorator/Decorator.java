package structural.decoratorPattern.decorator;

import structural.decoratorPattern.models.LibraryItem;

public interface Decorator extends LibraryItem {

	void borrowItem(String name);

	void returnItem(String name);

	LibraryItem getLibraryItem();
}