package problem2_BookShop;

public class GoldenEditionBook extends Book {

    public GoldenEditionBook(String author, String title, double price) {
        super(author, title, price);
    }

    @Override
    protected void setPrice(double price) {
        double goldenPrice = price * 1.3;
        super.setPrice(goldenPrice);
    }
}