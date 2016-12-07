package app.terminal;

import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

@Component
public class Terminal implements CommandLineRunner {

    //@Autowired
    //private AuthorService authorService;
    //
    //@Autowired
    //private BookService bookService;
    //
    //@Autowired
    //private CategoryService categoryService;

    @Override
    public void run(String... strings) throws Exception {

        //List<Book> books = (List<Book>) this.bookService.findByReleaseDateYearAfter(2000);
        //System.out.println(books.size());
        //for (Book book : books) {
        //    System.out.println(book.getTitle());
        //}
    }
}