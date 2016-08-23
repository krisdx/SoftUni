package structural.flyweightPattern.models;

public class LetterZ extends AbstractLetter implements Letter {

	public LetterZ() {
		this.setSymbol('Z');
		this.setHeight(100);
		this.setWidth(100);
		this.setAscent(68);
		this.setDescent(0);
	}
}