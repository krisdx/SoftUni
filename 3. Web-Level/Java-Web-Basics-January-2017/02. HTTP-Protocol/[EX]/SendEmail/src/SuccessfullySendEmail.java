import java.io.IOException;

public class SuccessfullySendEmail {
	
	public static void main(String[] args) throws IOException {
		System.out.println("Content-Type: text/html\n\n");
		System.out.println(WebUtils.readFile("/var/www/cgi/SendEmail/successfully-send-email.html"));
	}
}	