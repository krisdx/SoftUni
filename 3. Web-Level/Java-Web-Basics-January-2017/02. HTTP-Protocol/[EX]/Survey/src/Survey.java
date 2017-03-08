import java.io.IOException;

public class Survey {
	
	public static void main(String[] args) throws IOException {
		System.out.println("Content-Type: text/html\n");
		System.out.println(WebUtils.readFile("/var/www/cgi/Survey/survey.html"));	
	}
}