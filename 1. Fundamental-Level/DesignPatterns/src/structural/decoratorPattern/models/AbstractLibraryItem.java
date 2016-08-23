package structural.decoratorPattern.models;

public abstract class AbstractLibraryItem implements LibraryItem {

	private String title;
	private int copiesCount;

	protected AbstractLibraryItem(String title, int copiesCount) {
		this.title = title;
		this.setCopiesCount(copiesCount);
	}

	@Override
	public String getTitle() {
		return this.title;
	}

	@Override
	public int getCopiesCount() {
		return this.copiesCount;
	}

	@Override
	public void setCopiesCount(int copiesCount) {
		this.copiesCount = copiesCount;
	}

	@Override
	public void display() {
		System.out.println(this.getClass().getSimpleName());
		System.out.println("- Title: " + this.getTitle());
		System.out.println("- Copies: " + this.getCopiesCount());
	}
}