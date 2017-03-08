package app.utils;

import java.io.*;
import java.net.URLDecoder;
import java.util.LinkedHashMap;
import java.util.Map;

public class WebUtils {

    public static Map<String, String> getParameters() throws IOException {
        Map<String, String> params = new LinkedHashMap<>();
        String input = "";
        if (isPost()) {
            try (BufferedReader reader = new BufferedReader(new InputStreamReader(System.in))) {
                input = reader.readLine();
            }
        } else {
            input = System.getProperty("cgi.query_string");
        }

        if (input == null || input.equals("")) {
            return params;
        }

        String[] parameters = null;
        try {
            parameters = URLDecoder.decode(input, "UTF-8").split("&");
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }

        for (String parameter : parameters) {
            String[] pair = parameter.split("=");
            if (pair.length > 1){
                params.put(pair[0], pair[1]);
            } else {
                params.put(pair[0], null);
            }
        }

        return params;
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

    public static boolean isPost() {
        String requestMethod = System.getProperty("cgi.request_method") == null ?
                "get" : System.getProperty("cgi.request_method");
        return requestMethod.equalsIgnoreCase("post");
    }
}