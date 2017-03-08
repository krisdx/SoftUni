package app.model.pages;

import app.model.cookie.Cookie;
import app.model.cookie.Session;
import app.model.cookie.SessionData;
import app.model.header.Header;
import app.repository.SessionRepository;
import app.utils.WebUtils;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

public class Home {

    private static Map<String, String> params;
    private static Map<String, Cookie> cookies;
    private static Header header;
    private static SessionRepository sessionRepository;

    static {
        params = new HashMap<>();
        cookies = new HashMap<>();
        header = new Header();
        sessionRepository = new SessionRepository();
    }

    public static void main(String[] args) throws IOException {
        readParams();
        header.printHeader();
        readCookies(args);
        readHtml();
    }

    private static void readParams() throws IOException {
        params = WebUtils.getParameters();
        for (String param : params.keySet()) {
            switch (param) {
                case "language":
                    setCookie("lang", params.get("language"));
                    break;
                case "sign-in":
                    goToSignIn();
                    break;
                case "sign-up":
                    goToSignUp();
                    break;
            }
        }
    }

    private static void goToSignUp() {
        header.setLocation("sign_up.cgi");
    }

    private static void goToSignIn() {
        header.setLocation("sign_in.cgi");
    }

    private static void setCookie(String key, String value) {
        Cookie cookie = new Cookie(key, value);
        header.addCookie(cookie);
    }

    private static void readCookies(String[] args) {
        if (args.length == 0) {
            return;
        }

        for (String cookie : args) {
            String[] tokens = cookie.split("=");
            String key = tokens[0];
            String value = tokens[1];
            value = value.replace(";", "");
            Cookie c = new Cookie(key, value);
            cookies.put(key, c);
        }
    }

    private static void readHtml() {
        Cookie sessionCookie = cookies.get("sid");
        String username = null;
        if (sessionCookie != null) {
            Long sessionId = Long.valueOf(sessionCookie.getValue());
            Session session = sessionRepository.findById(sessionId);
            // Sign Out
            if (params.containsKey("signout")) {
                signOut(sessionId);
                session = null;
            }

            if (session != null) {
                Set<SessionData> sessionData = session.getSessionData();
                for (SessionData data : sessionData) {
                    if (data.getKey().equalsIgnoreCase("username")) {
                        username = data.getValue();
                    }
                }
            }
        }

        Cookie languageCookie = null;
        if (!WebUtils.isPost()) {
            if (cookies.containsKey("lang")) {
                languageCookie = cookies.get("lang");
                if (languageCookie.getValue().equalsIgnoreCase("de")) {
                    readHtmlDe();
                } else {
                    readHtmlEn();
                }
            } else {
                readHtmlEn();
            }
        } else {
            if (params.containsKey("language")) {
                String language = params.get("language");
                if (language.equalsIgnoreCase("de")) {
                    readHtmlDe();
                } else {
                    readHtmlEn();
                }
            } else {
                readHtmlEn();
            }
        }
    }

    private static void signOut(Long sessionId) {
    }

    private static void readHtmlEn() {
        try {
            System.out.println(WebUtils.readFile("/var/www/html/resources/html/home.html"));
        } catch (IOException e) {
            System.out.println(System.getProperty("user.dir") + "/resources/html/home.html");
            System.out.println("<br>");
            System.out.println(e.getMessage());
        }
    }

    private static void readHtmlDe() {
        try {
            System.out.println(WebUtils.readFile(System.getProperty("user.dir") + "/src/main/resources/html/home-de.html"));
        } catch (IOException e) {
            System.out.println("v read html-de sam");
            System.out.println(e.getMessage());
        }
    }
}