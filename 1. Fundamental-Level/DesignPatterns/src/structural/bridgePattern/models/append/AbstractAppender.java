package structural.bridgePattern.models.append;

import structural.bridgePattern.models.format.Formatter;

public abstract class AbstractAppender implements Appender {

	private Formatter formatter;

	protected AbstractAppender(Formatter formatter) {
		this.formatter = formatter;
	}

	public Formatter getFormatter() {
		return this.formatter;
	}
}