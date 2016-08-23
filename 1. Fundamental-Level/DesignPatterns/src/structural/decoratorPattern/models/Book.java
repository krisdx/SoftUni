package structural.decoratorPattern.models;

public class Book extends AbstractLibraryItem implements LibraryItem {

	private String author;

	public Book(String title, int copiesCount, String author) {
		super(title, copiesCount);
		this.author = author;
	}

	public String getAuthor() {
		return this.author;
	}

	@Override
	public void display() {
		super.display();
		System.out.println("- Author: " + this.getAuthor());
	}
}