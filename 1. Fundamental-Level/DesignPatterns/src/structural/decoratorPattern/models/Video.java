package structural.decoratorPattern.models;

public class Video extends AbstractLibraryItem implements LibraryItem {

	private String director;
	private int playTime;

	public Video(String title, int copiesCount, String director, int playTime) {
		super(title, copiesCount);
		this.director = director;
		this.playTime = playTime;
	}

	public String getDirector() {
		return this.director;
	}

	public int getPlayTime() {
		return this.playTime;
	}

	@Override
	public void display() {
		super.display();
		System.out.println("- Director: " + this.getDirector());
		System.out.println("- Playtime: " + this.getPlayTime());
	}
}