import java.io.IOException;
import java.net.URLEncoder;
import java.util.Map;

public class EmailCheck {

	private static final String SUBJECT_LENGTH_ERROR_MESSAGE = "The length of the subject must be less than 100 symbols!";	
	
	public static void main(String[] args) throws IOException {
		System.out.println("Content-Type: text/html");
		
		Map<String, String> params = WebUtils.getParameters();
		if (params.containsKey("subject") && params.get("subject").length() > 100) {
			redirect("send_email.cgi?error=" + URLEncoder.encode(SUBJECT_LENGTH_ERROR_MESSAGE, "UTF-8"));
			return;
		}
		
		redirect("successfully_send_email.cgi");
	}
	
	private static void redirect(String location) {
		System.out.println("Location: " + location + "\n");
	}
}