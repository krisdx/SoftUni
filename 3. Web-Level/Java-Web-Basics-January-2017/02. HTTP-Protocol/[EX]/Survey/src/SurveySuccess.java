import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.URLDecoder;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class SurveySuccess {
	
	public static void main(String[] args) throws IOException {
		String survey = null;
		try (BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
			survey = reader.readLine();
        }
		
		String[] params = URLDecoder.decode(survey, "UTF-8").split("&");
		try (BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream("/var/www/cgi/Survey/survey-results.csv", true)))) {
			List<String> filteredParams = Arrays.stream(params)
					.filter(p -> p.split("=").length > 1)
					.collect(Collectors.toList());
			writer.write(String.join(", ", filteredParams));
			writer.write(System.lineSeparator());
        }
		
		System.out.println("Content-Type: text/html\n");
		System.out.println(WebUtils.readFile("/var/www/cgi/Survey/survey-success.html"));
	}
}   