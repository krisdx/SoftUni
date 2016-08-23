package structural.flyweightPattern.models;

public class LetterA extends AbstractLetter implements Letter {

	public LetterA() {
		this.setSymbol('A');
		this.setHeight(100);
		this.setWidth(120);
		this.setAscent(70);
		this.setDescent(0);
	}
}