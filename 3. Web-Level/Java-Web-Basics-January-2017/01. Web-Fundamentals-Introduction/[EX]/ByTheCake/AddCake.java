import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class AddCake {
	public static void main(String[] args) throws IOException {
	    System.out.println("Content-Type: text/html\n\n");
	    
	    System.out.println(WebUtils.readFile("/var/www/cgi/ByTheCake/add-cake.html"));
	    
	    Map<String, String> params = WebUtils.getParameters();
	    List<String> content = new ArrayList<>();
	    int i = 0;
	    String str = "";
	    for (Map.Entry<String, String> entry : params.entrySet()) {
	    	if (i % 2 == 1) {
	    		str += String.format(", %s: %s", entry.getKey(), entry.getValue());
	    	} else {
	    		str += String.format("%s: %s", entry.getKey(), entry.getValue());
	    	}
	    	
	    	i++;
	    	if (i % 2 == 0) {
	    		content.add(str);
	    		str = "";
	    	}
		}

	    WebUtils.writeToFile(content, "/var/www/cgi/ByTheCake/database.csv");
	}	
}