import java.io.IOException;
import java.net.URLDecoder;
import java.util.Map;

public class SendEmail {
	
	public static void main(String[] args) throws IOException {
		System.out.println("Content-Type: text/html\n\n");
		System.out.println(WebUtils.readFile("/var/www/cgi/SendEmail/send-email.html"));
		
		Map<String, String> params = WebUtils.getParameters();
		if (params.containsKey("error")) {
			System.out.printf("<p style=\"color: red\">%s</p>", URLDecoder.decode(params.get("error"), "UTF-8"));
		}
	}
}