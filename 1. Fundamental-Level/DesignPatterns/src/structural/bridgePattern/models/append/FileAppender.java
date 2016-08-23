package structural.bridgePattern.models.append;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.security.cert.CRLReason;

import structural.bridgePattern.models.format.Formatter;

public class FileAppender extends AbstractAppender implements Appender {

	public FileAppender(Formatter formatter) {
		super(formatter);
	}

	@Override
	public void append(String message) throws IOException {
		String outputFilePath = this.getFilePath();
		try (BufferedWriter writer = new BufferedWriter(new FileWriter(outputFilePath))) {
			String formattedMessage = this.getFormatter().format(message);
			writer.write(formattedMessage);
			writer.flush();
		}
	}

	private String getFilePath() {
		String currentProjcetDirectory = System.getProperty("user.dir");
		String currecntPackage = this.getClass().getPackage().getName().replace(".", "\\");
		String fileName = "text.txt";
		return String.format("%s\\src\\%s\\%s", currentProjcetDirectory, currecntPackage, fileName);
	}
}