package problem2_BookShop;

public class Book {
    private String title;
    private String author;
    private double price;

    public Book(String author, String title, double price) {
        this.setTitle(title);
        this.setAuthor(author);
        this.setPrice(price);
    }

    private void setTitle(String title) {
        if (title == null || title.trim().length() < 3){
            throw new IllegalArgumentException("Title not valid!");
        }

        this.title = title;
    }


    private void setAuthor(String author) {
        if(author == null || !this.isAuthorNameValid(author)){
            throw new IllegalArgumentException("Author not valid!");
        }

        this.author = author;
    }

    protected void setPrice(double price) {
        if (price <= 0){
            throw new IllegalArgumentException("Price not valid!");
        }

        this.price = price;
    }

    private boolean isAuthorNameValid(String author) {
        String[] authorParams = author.split("\\s+");
        if (authorParams.length > 1 && Character.isDigit(authorParams[1].charAt(0))){
            return false;
        }

        return true;
    }

    @Override
    public String toString() {
        return "Type: " + this.getClass().getSimpleName() + System.lineSeparator() +
                "Title: " + this.title + System.lineSeparator() +
                "Author: " + this.author + System.lineSeparator() +
                "Price: " + String.format("%.1f", this.price) + System.lineSeparator();
    }
}