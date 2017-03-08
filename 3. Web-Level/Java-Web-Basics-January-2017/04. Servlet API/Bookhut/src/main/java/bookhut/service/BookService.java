package bookhut.service;

import bookhut.model.buildingModel.AddBookModel;
import bookhut.model.viewModel.ViewBookModel;

import java.util.List;

public interface BookService {
    void saveBook(AddBookModel addBookModel);

    List<ViewBookModel> getAllBooks();

    ViewBookModel findBookByTitle(String title);

    void deleteBookByTitle(String title);
}