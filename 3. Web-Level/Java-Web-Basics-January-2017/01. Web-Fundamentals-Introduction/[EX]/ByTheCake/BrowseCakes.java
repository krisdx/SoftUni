import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class BrowseCakes {
	public static void main(String[] args) throws IOException {
	    System.out.println("Content-Type: text/html\n\n");	    
	    System.out.println(WebUtils.readFile("/var/www/cgi/ByTheCake/browse-cakes.html"));
	    
	    Map<String, String> searchParams = WebUtils.getParameters();
	    String searchStr = (String) searchParams.values().toArray()[0];
	    
	    String data = WebUtils.readFile("/var/www/cgi/ByTheCake/database.csv");
	    String[] cake = data.split("\n");
	    List<String> content = new ArrayList<>();
	    for (int i = 0; i < cake.length; i++) {
	    	String[] cakeArgs = cake[i].split("[,:]+");
	    	String name = cakeArgs[1];
	    	String price = cakeArgs[3];
	    	if (name.toLowerCase().contains(searchStr)) {
	    		content.add(String.format("%s: %s %s: %s", cakeArgs[0], name, cakeArgs[2], price));
	    	}	    	
	    }

	    for (String line : content) {
			System.out.println(line + "<br>");
		}
	}
}
