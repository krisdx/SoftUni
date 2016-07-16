import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.temporal.ChronoUnit;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.concurrent.TimeUnit;

public class Problem10_DateModifier {
    public static void main(String[] args) throws IOException, ClassNotFoundException, NoSuchMethodException, ParseException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        DateModifier dateModifier = new DateModifier();
        System.out.println(dateModifier.getDaysDifference(reader.readLine(), reader.readLine()));
    }
}

class DateModifier {
    private long daysDifference;

    public long getDaysDifference(String firstDate, String secondDate) throws ParseException {
//        String[] firstDateArgs = firstDate.split("\\s+");
//        Integer firstDateYear = Integer.valueOf(firstDateArgs[0]);
//        Integer firstDateMonth = Integer.valueOf(firstDateArgs[1]);
//        Integer firstDateDay = Integer.valueOf(firstDateArgs[2]);
//
//        String[] secondDateArgs = secondDate.split("\\s+");
//        Integer secondDateYear = Integer.valueOf(secondDateArgs[0]);
//        Integer secondDateMonth = Integer.valueOf(secondDateArgs[1]);
//        Integer secondDateDay = Integer.valueOf(secondDateArgs[2]);
//
//        Integer yearDifference = Math.abs(firstDateYear - secondDateYear);
//        Integer monthDifference = Math.abs(firstDateMonth - secondDateMonth);
//        Integer daysDifference = Math.abs(firstDateDay - secondDateDay);

        Calendar cal1 = new GregorianCalendar();
        Calendar cal2 = new GregorianCalendar();

        SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMdd");

        Date date = sdf.parse(firstDate);
        Date d1 = sdf.parse(firstDate);
        Date d2 = sdf.parse(secondDate);
        cal1.setTime(date);
        date = sdf.parse(secondDate);
        cal2.setTime(date);

        long diff = d1.getTime() - d2.getTime();
       return TimeUnit.DAYS.convert(diff, TimeUnit.DAYS);
    }

    private int daysBetween(Date d1, Date d2) {
        return (int) ((d2.getTime() - d1.getTime()) / (1000 * 60 * 60 * 24));
    }
}
