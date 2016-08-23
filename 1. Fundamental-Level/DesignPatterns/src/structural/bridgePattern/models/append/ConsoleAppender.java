package structural.bridgePattern.models.append;

import structural.bridgePattern.models.format.Formatter;

public class ConsoleAppender extends AbstractAppender implements Appender {

	public ConsoleAppender(Formatter formatter) {
		super(formatter);
	}

	@Override
	public void append(String message) {
		System.out.println(this.getFormatter().format(message));
	}
}