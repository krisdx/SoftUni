package app.model.pages;

import app.model.User;
import app.model.cookie.Cookie;
import app.model.header.Header;
import app.repository.UserRepository;
import app.utils.WebUtils;

import java.io.IOException;
import java.net.URLDecoder;
import java.util.HashMap;
import java.util.Map;

public class SignUp {

    private static Map<String, String> params;
    private static Header header;
    private static UserRepository userRepository;

    static {
        params = new HashMap<>();
        header = new Header();
        userRepository = new UserRepository();
    }

    public static void main(String[] args) throws IOException {
        readParams();
        header.printHeader();
        readHtml();
    }

    private static void readParams() throws IOException {
        params = WebUtils.getParameters();
        String username = null;
        String password = null;
        for (String param : params.keySet()) {
            switch (param) {
                case "username":
                    username = params.get("username");
                    break;
                case "password":
                    password = params.get("password");
                    break;
                case "sign-up":
                    if (username.isEmpty() || password.isEmpty()) {
                        return;
                    }

                    User newUser = new User(username, password);
                    userRepository.createUser(newUser);
                    header.setLocation("sign_in.cgi");
                    break;
                case "cancel":
                    header.setLocation("home.cgi");
                    break;
            }
        }
    }

    private static void readHtml() {
//        Cookie languageCookie = null;
//        if (!WebUtils.isPost()) {
//            if (cookies.containsKey("lang")) {
//                languageCookie = cookies.get("lang");
//                if (languageCookie.getValue().equalsIgnoreCase("de")) {
//                    readHtmlDe();
//                } else {
//                    readHtmlEn();
//                }
//            } else {
//                readHtmlEn();
//            }
//        } else {
//            if (params.containsKey("language")) {
//                String language = params.get("language");
//                if (language.equalsIgnoreCase("de")) {
//                    readHtmlDe();
//                } else {
//                    readHtmlEn();
//                }
//            } else {
//                readHtmlEn();
//            }
//        }
        try {
            System.out.println(WebUtils.readFile("/var/www/html/resources/html/sign-up.html"));
        } catch (IOException e) {
            System.out.println("/var/www/html/resources/html/sign-up.html");
            System.out.println("<br>");
            System.out.println(e.getMessage());
        }
    }
}