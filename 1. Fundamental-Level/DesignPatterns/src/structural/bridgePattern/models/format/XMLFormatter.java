package structural.bridgePattern.models.format;

public class XMLFormatter implements Formatter {

	@Override
	public String format(String message) {
		return "<message>" + message + "</message>";
	}
	
}