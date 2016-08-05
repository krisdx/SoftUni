package problem4_Telephony;

public class Smartphone implements Callable, Browseable {

    @Override
    public void browse(String site) {
        System.out.printf("Browsing: %s!%n", site);
    }

    @Override
    public void call(String number) {
        System.out.println("Calling... " + number);
    }
}