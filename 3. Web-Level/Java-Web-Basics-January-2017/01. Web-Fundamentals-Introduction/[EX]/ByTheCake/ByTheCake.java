import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

public class ByTheCake {
	public static void main(String[] args) throws IOException { 
	    System.out.println("Content-Type: text/html\n\n");
	    System.out.println(WebUtils.readFile("/var/www/cgi/ByTheCake/by-the-cake.html"));
	    System.out.println(System.getProperty("cgi.query_string"));
	}
}