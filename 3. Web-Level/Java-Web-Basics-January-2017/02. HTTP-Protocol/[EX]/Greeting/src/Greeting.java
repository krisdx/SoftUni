import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Map;

public class Greeting {
	public static void main(String[] args) throws IOException {
		System.out.println("Content-Type: text/html\n\n");
		
		Map<String, String> params = WebUtils.getParameters();
		try (BufferedReader reader = new BufferedReader(new InputStreamReader(new FileInputStream("/var/www/cgi/Greeting/info.csv")))) {
			String[] names = reader.readLine().split(",");
			System.out.printf("<h1>Hello %s %s at age %s</h1", names[0], names[1], params.get("age"));
		}
	}
}