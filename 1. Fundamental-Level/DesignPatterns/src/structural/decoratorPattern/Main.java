package structural.decoratorPattern;

import structural.decoratorPattern.decorator.BorrowableLibraryItem;
import structural.decoratorPattern.models.Book;
import structural.decoratorPattern.models.LibraryItem;
import structural.decoratorPattern.models.Video;

public class Main {

	public static void main(String[] args) {

		/**
		 * Decorator pattern allows adding responsibilities to an object
		 * dynamically. Making object that wraps the original object.
		 * 
		 * Prevents from class explosion problem. Supports the Open-Closed
		 * principle.
		 */

		LibraryItem book = new Book("Programirane = ++Algoritmi", 150, "Preslav Nakov");
		book.display();
		System.out.println();

		LibraryItem video = new Video("MySQL Introduction", 150, "", 20);
		video.display();
		System.out.println();

		BorrowableLibraryItem borrableBook = new BorrowableLibraryItem(book);
		borrableBook.borrowItem("Pesho");
		borrableBook.borrowItem("Gosho");

		System.out.println("Borrable book display method: ");
		borrableBook.display();
	}
}