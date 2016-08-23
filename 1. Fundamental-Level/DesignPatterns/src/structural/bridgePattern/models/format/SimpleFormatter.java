package structural.bridgePattern.models.format;

public class SimpleFormatter implements Formatter {

	@Override
	public String format(String message) {
		return "Message: " + message;
	}

}