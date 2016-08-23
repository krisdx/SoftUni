package structural.decoratorPattern.decorator;

import java.util.ArrayList;
import java.util.List;

import structural.decoratorPattern.models.LibraryItem;

public class BorrowableLibraryItem implements Decorator {

	private LibraryItem libraryItem;
	private List<String> borrowers;

	public BorrowableLibraryItem(LibraryItem libraryItem) {
		this.libraryItem = libraryItem;
		this.borrowers = new ArrayList<>();
	}

	@Override
	public LibraryItem getLibraryItem() {
		return this.libraryItem;
	}

	@Override
	public String getTitle() {
		return this.getLibraryItem().getTitle();
	}

	@Override
	public int getCopiesCount() {
		return this.getLibraryItem().getCopiesCount();
	}

	@Override
	public void setCopiesCount(int copiesCount) {
		this.getLibraryItem().setCopiesCount(copiesCount);
	}

	@Override
	public void display() {
		this.getLibraryItem().display();
		for (String borrower : this.borrowers) {
			System.out.println("borrower: " + borrower);
		}
	}

	@Override
	public void borrowItem(String name) {
		this.borrowers.add(name);
		this.getLibraryItem().setCopiesCount(this.getLibraryItem().getCopiesCount() - 1);
	}

	@Override
	public void returnItem(String name) {
		this.borrowers.remove(name);
		this.getLibraryItem().setCopiesCount(this.getLibraryItem().getCopiesCount() + 1);
	}
}