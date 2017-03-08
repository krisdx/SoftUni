package bookhut.model.buildingModel;

public class AddBookModel {

    private String title;
    private String author;
    private int pages;

    public AddBookModel(String title, String author, int pages) {
        this.setTitle(title);
        this.setAuthor(author);
        this.setPages(pages);
    }

    public String getTitle() {
        return this.title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAuthor() {
        return this.author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public int getPages() {
        return this.pages;
    }

    public void setPages(int pages) {
        this.pages = pages;
    }
}