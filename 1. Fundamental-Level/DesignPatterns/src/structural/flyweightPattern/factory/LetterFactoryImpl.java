package structural.flyweightPattern.factory;

import java.util.LinkedHashMap;
import java.util.Map;

import structural.flyweightPattern.models.AbstractLetter;
import structural.flyweightPattern.models.Letter;

public class LetterFactoryImpl implements LetterFactory {

	private static final String CHARACTER_PREFIX = "Letter";

	private static final String CHARACTERS_PACKAGE = 
			AbstractLetter.class.getPackage().getName();

	private Map<Character, Letter> chars;

	public LetterFactoryImpl() {
		this.chars = new LinkedHashMap<>();
	}

	@Override
	@SuppressWarnings("unchecked")
	public Letter getCharacter(char key) throws ReflectiveOperationException {

		if (this.chars.containsKey(key)) {
			return this.chars.get(key);
		}

		String path = CHARACTERS_PACKAGE + "." + CHARACTER_PREFIX + key;
		Class<Letter> letterClass = (Class<Letter>) Class.forName(path);

		Letter character = letterClass.newInstance();
		this.chars.put(key, character);
		return character;
	}
}