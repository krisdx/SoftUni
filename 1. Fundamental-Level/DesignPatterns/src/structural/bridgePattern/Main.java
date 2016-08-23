package structural.bridgePattern;

import java.io.IOException;

import structural.bridgePattern.models.append.Appender;
import structural.bridgePattern.models.append.FileAppender;
import structural.bridgePattern.models.format.*;

public class Main {

	public static void main(String[] args) {

		/**
		 * Bridge pattern decouples an abstraction from its implementation so
		 * that the two can vary independently. Publish interface in an
		 * inheritance hierarchy, and bury implementation in its own inheritance
		 * hierarchy.
		 */

		Formatter formatter = new SimpleFormatter();
		Appender appender = new FileAppender(formatter);

		try {
			appender.append("Bridge Pattern");
		} catch (IOException ex) {
			ex.printStackTrace();
		}
	}
}