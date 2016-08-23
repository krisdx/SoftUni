package structural.bridgePattern.models.append;

import java.io.IOException;

public interface Appender {
	void append(String message) throws IOException;
}