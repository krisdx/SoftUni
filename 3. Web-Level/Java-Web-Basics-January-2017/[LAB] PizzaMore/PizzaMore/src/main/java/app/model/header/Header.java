package app.model.header;

import app.model.cookie.Cookie;

import java.util.ArrayList;
import java.util.List;

public class Header {

    private String contentType;
    private String location;
    private List<Cookie> cookies;

    public Header() {
        this.contentType = "Content-Type: text/html";
        this.cookies = new ArrayList<>();
    }

    public void setLocation(String location) {
        this.location = location;
    }

    public void addCookie(Cookie cookie) {
        this.cookies.add(cookie);
    }

    public void printHeader() {
        System.out.println(this.contentType);

        if (!this.cookies.isEmpty()) {
            String cookies = "";
            for (Cookie cookie : this.cookies) {
                cookies += cookie.getCookie();
            }

            System.out.println("Set-Cookie: " + cookies.trim());
        }

        if (this.location != null) {
            System.out.println("Location: " + this.location);
        }

        System.out.println(); // End of header
    }
}