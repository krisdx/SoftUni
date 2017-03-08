import java.io.IOException;
import java.net.URLEncoder;
import java.util.Map;

public class LoginCheck {
	
	private static final String USERNAME = "suAdmin";
	private static final String PASSWORD = "aDmInPw17";	
	
	private static final String INVALID_USERNAME_MESSAGE = "Invalid username!";
	private static final String INVALID_PASSWORD_MESSAGE = "Invalid password!";	
	
	public static void main(String[] args) throws IOException {
		System.out.println("Content-Type: text/html");
		
		Map<String, String> params = WebUtils.getParameters();		
		if (params.containsKey("username") && !params.get("username").equals(USERNAME)) {
			redirect("login.cgi?error=" + URLEncoder.encode(INVALID_USERNAME_MESSAGE, "UTF-8"));
			return;
		}

		if (params.containsKey("password") && !params.get("password").equals(PASSWORD)) {
			redirect("login.cgi?error=" + URLEncoder.encode(INVALID_PASSWORD_MESSAGE, "UTF-8"));
			return;
		}
		
		redirect("send_email.cgi");
	}
	
	private static void redirect(String location) {
		System.out.println("Location: " + location + "\n");
	}
}