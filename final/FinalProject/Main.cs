using System;

public class Main
{
    public void Start()
    {
        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 1925);
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "Fiction", 1960);

        Library library = new Library();
        BookManager bookManager = new BookManager();
        Reader reader = new Reader("John Doe", "john@example.com");

        library.AddBook(book1);
        library.AddBook(book2);
        bookManager.AddBook(book1);
        bookManager.AddBook(book2);

        reader.AddReadBook(book1);

        BookRecommender bookRecommender = new BookRecommender(library);
        UserInterface ui = new UserInterface(library, reader);

        ui.ShowMenu(); // Iniciar la interfaz de usuario
    }

}
