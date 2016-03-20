import java.util.Locale;
import java.util.Scanner;

public class Problem1_TheBetterMusicProducer {
    public static void main(String[] args) {
        Locale.setDefault(Locale.US);
        Scanner input = new Scanner(System.in);

        double soldAlbumsInEurope = input.nextDouble();
        double albumPriceInEuro = input.nextDouble();
        double albumsSoldInNorthAmerica = input.nextDouble();
        double albumPriceInDollars = input.nextDouble();
        double albumsSoldInSouthAmerica = input.nextDouble();
        double albumPriceInPeros = input.nextDouble();
        double numbersOfConcerts = input.nextDouble();
        double singleConcertProfit = input.nextDouble();

        double soldAlbumsPriceInEurope = (soldAlbumsInEurope * albumPriceInEuro) * 1.94;
        double soldAlbumsPriceInNorthAmerica = (albumsSoldInNorthAmerica * albumPriceInDollars) * 1.72;
        double soldAlbumsPriceInSouthAmerica = (albumsSoldInSouthAmerica * albumPriceInPeros) / 332.74;

        double allAlbumsProfit = soldAlbumsPriceInEurope + soldAlbumsPriceInNorthAmerica + soldAlbumsPriceInSouthAmerica;
        allAlbumsProfit -= allAlbumsProfit * 0.35;
        allAlbumsProfit -= allAlbumsProfit * 0.20;

        double concertProfit = (numbersOfConcerts * singleConcertProfit) * 1.94;
        if (concertProfit > 100000) {
            concertProfit -= concertProfit * 0.15;
        }

        if (allAlbumsProfit > concertProfit) {
            System.out.printf("Let's record some songs! They'll bring us %.2flv.", allAlbumsProfit);
        } else {
            System.out.printf("On the road again! We'll see the world and earn %.2flv.", concertProfit);
        }
    }
}