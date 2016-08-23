package structural.flyweightPattern;

import structural.flyweightPattern.factory.LetterFactory;
import structural.flyweightPattern.factory.LetterFactoryImpl;
import structural.flyweightPattern.models.Letter;

public class Main {

	public static void main(String[] args) throws ReflectiveOperationException {

		/**
		 * Flyweight pattern uses sharing to support large numbers of
		 * fine-grained objects efficiently. Reduces storage costs for large
		 * number of objects.
		 */

		LetterFactory characterFactory = new LetterFactoryImpl();

		String document = "AAZZBBZB";
		int pointSize = 10;
		for (Character ch : document.toCharArray()) {
			pointSize++;
			Letter letter = characterFactory.getCharacter(ch);
			letter.display(pointSize);
		}
	}
}