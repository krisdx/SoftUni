import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.net.URLDecoder;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

public class WebUtils {
	
	public static boolean isPost() {
        String requestMethod = System.getProperty("cgi.request_method") == null ? 
        		"get" : System.getProperty("cgi.request_method");
        return requestMethod.equalsIgnoreCase("post");
    }

    public static Map<String, String> getParameters() throws IOException {
        Map<String, String> parametersMap = new LinkedHashMap<>();
        String input = "";
        if (isPost()) {
            try (BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
                input = reader.readLine();
            }
        } else {
            input = System.getProperty("cgi.query_string");
//        	input = "num1=1&sign=%2B&num2=1";
        }
        
        String[] parameters = null;
        try {
            parameters = URLDecoder.decode(input, "UTF-8").split("&");
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }
        
        for (String parameter : parameters) {
            String[] pair = parameter.split("=");
            parametersMap.put(pair[0], pair[1]);
        }
        
        return parametersMap;
    }

    public static String readFile(String absolutePath) throws IOException {
        StringBuilder sb = new StringBuilder();
        try (BufferedReader reader = new BufferedReader(new InputStreamReader(new FileInputStream(absolutePath)))) {
            String line = reader.readLine();
            while (line != null) {
                sb.append(line).append(System.lineSeparator());
                line = reader.readLine();
            }
        }
        
        return sb.toString();
    }
    
    public static void writeToFile(List<String> content, String absolutePath) throws IOException {
        try (BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(absolutePath, true)))) {
        	for (String line : content) { 
        		writer.append(line).append(System.lineSeparator());
        	}
        }
    }
}