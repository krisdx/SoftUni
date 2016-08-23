package structural.flyweightPattern.models;

public class LetterB extends AbstractLetter implements Letter {
	
	public LetterB() {
		this.setSymbol('B');
		this.setHeight(100);
		this.setWidth(140);
		this.setAscent(72);
		this.setDescent(0);
	}
}