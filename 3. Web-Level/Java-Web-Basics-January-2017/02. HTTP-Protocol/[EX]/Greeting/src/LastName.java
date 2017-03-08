import java.io.BufferedWriter;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.util.Map;

public class LastName {
	
	public static void main(String[] args) throws IOException {
		Map<String, String> params = WebUtils.getParameters();
		try (BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream("/var/www/cgi/Greeting/info.csv")))) {
			writer.append(params.get("first-name"));
		} 
		
		System.out.println("Content-Type: text/html\n");
		System.out.println(WebUtils.readFile("/var/www/cgi/Greeting/last-name.html"));
	}
}