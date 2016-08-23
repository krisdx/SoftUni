package structural.flyweightPattern.models;

public abstract class AbstractLetter implements Letter {

	private char symbol;
	private int width;
	private int height;
	private int ascent;
	private int descent;
	private int pointSize;

	@Override
	public char getSymbol() {
		return this.symbol;
	}

	protected void setSymbol(char symbol) {
		this.symbol = symbol;
	}

	@Override
	public int getWidth() {
		return this.width;
	}

	protected void setWidth(int width) {
		this.width = width;
	}

	@Override
	public int getHeight() {
		return this.height;
	}

	protected void setHeight(int height) {
		this.height = height;
	}

	@Override
	public int getAscent() {
		return this.ascent;
	}

	protected void setAscent(int ascent) {
		this.ascent = ascent;
	}

	@Override
	public int getDescent() {
		return this.descent;
	}

	protected void setDescent(int descent) {
		this.descent = descent;
	}

	@Override
	public int getPointSize() {
		return this.pointSize;
	}

	protected void setPointSize(int pointSize) {
		this.pointSize = pointSize;
	}

	@Override
	public void display(int pointSize) {
		this.setPointSize(pointSize);
		System.out.printf("%s (point size %d)%n", this.getSymbol(), this.getPointSize());
	}
}
