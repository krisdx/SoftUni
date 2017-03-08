import java.io.IOException;

public class Login {
	public static void main(String[] args) throws IOException {
		System.out.println("Content-Type: text/html\n\n");
		System.out.println(WebUtils.readFile("/var/www/cgi/Login/login.html"));

		Object[] params = WebUtils.getParameters().values().toArray();
		System.out.println(String.format("Hi %s, your password is %s", params[0], params[1]));
	}
}