package main.bg.softuni.staticData;

import java.util.Set;
import java.util.HashSet;

public class SessionData {
    public static String currentPath = System.getProperty("user.dir");
    public static Set<Thread> threadPool = new HashSet<>();
}