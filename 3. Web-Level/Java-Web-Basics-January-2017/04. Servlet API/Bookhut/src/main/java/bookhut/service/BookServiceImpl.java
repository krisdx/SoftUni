package bookhut.service;

import bookhut.entity.Book;
import bookhut.model.buildingModel.AddBookModel;
import bookhut.model.viewModel.ViewBookModel;
import bookhut.repository.BookRepository;
import bookhut.repository.BookRepositoryImpl;
import org.modelmapper.ModelMapper;

import java.util.ArrayList;
import java.util.List;

public class BookServiceImpl implements BookService {

    private BookRepository bookRepository;
//    private ModelMapper modelMapper;

    public BookServiceImpl() {
//        this.modelMapper = new ModelMapper();
        this.bookRepository = BookRepositoryImpl.getInstance();
    }

    @Override
    public void saveBook(AddBookModel addBookModel) {
        ModelMapper modelMapper = new ModelMapper();
        Book book = modelMapper.map(addBookModel, Book.class);
        this.bookRepository.saveBook(book);
    }

    @Override
    public List<ViewBookModel> getAllBooks() {
        ModelMapper modelMapper = new ModelMapper();
        List<Book> books = this.bookRepository.getAllBooks();
        List<ViewBookModel> viewBookModels = new ArrayList<>();
        for (Book book : books) {
            ViewBookModel viewBookModel = modelMapper.map(book, ViewBookModel.class);
            viewBookModels.add(viewBookModel);
        }

        return viewBookModels;
    }

    @Override
    public ViewBookModel findBookByTitle(String title) {
        ModelMapper modelMapper = new ModelMapper();
        Book book = this.bookRepository.findBookByTitle(title);
        return modelMapper.map(book, ViewBookModel.class);
    }

    @Override
    public void deleteBookByTitle(String title) {
        this.bookRepository.deleteBookByTitle(title);
    }
}