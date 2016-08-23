package structural.flyweightPattern.models;

public interface Letter {
	char getSymbol();

	int getWidth();

	int getHeight();

	int getAscent();

	int getDescent();

	int getPointSize();

	void display(int pointSize);
}