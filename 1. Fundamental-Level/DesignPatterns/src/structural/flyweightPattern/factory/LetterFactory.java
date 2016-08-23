package structural.flyweightPattern.factory;

import structural.flyweightPattern.models.Letter;

public interface LetterFactory {
	Letter getCharacter(char key) throws ReflectiveOperationException;
}