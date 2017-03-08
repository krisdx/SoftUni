package app.model.pages;

import app.model.User;
import app.model.cookie.Cookie;
import app.model.cookie.Session;
import app.model.header.Header;
import app.repository.SessionRepository;
import app.repository.UserRepository;
import app.utils.WebUtils;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

public class SignIn {

    private static Map<String, String> params;
    private static Map<String, Cookie> cookies;
    private static Header header;
    private static UserRepository userRepository;
    private static SessionRepository sessionRepository;

    static {
        params = new HashMap<>();
        cookies = new HashMap<>();
        header = new Header();
        userRepository = new UserRepository();
        sessionRepository = new SessionRepository();
    }

    public static void main(String[] args) throws IOException {
        readParams();
        header.printHeader();
        readHtml();
    }

    private static void readParams() throws IOException {
        params = WebUtils.getParameters();
        for (String param : params.keySet()) {
            switch (param) {
                case "sing-in":
                    signIn();
                    break;
                case "cancel":
                    header.setLocation("home.cgi");
                    break;
            }
        }
    }

    private static void signIn() {
        String username =  params.get("username");
        String password = params.get("password");
        User user = userRepository.findByUsernameAndPassword(username, password);
        if (user == null) {
            return;
        }

        Session session = new Session();
        session.addData("username", username);
        Long sessionId = sessionRepository.createSession(session);
        Cookie sessionCookie = new Cookie("sid", sessionId.toString());
        header.addCookie(sessionCookie);

        Cookie rememberMeCookie = new Cookie("rememberme", "yes");
        header.addCookie(rememberMeCookie);
        System.out.println("vlizam");
        header.setLocation("home.cgi");
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
            System.out.println(WebUtils.readFile("/var/www/html/resources/html/sign-in.html"));
        } catch (IOException e) {
            System.out.println("/var/www/html/resources/html/sign-up.html");
            System.out.println("<br>");
            System.out.println(e.getMessage());
        }
    }
}