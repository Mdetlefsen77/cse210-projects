using System.Collections.Generic;

public class Library
{
    // List of books in the library
    private List<Book> books;

    // Constructor
    public Library()
    {
        books = new List<Book>();
    }

    // Method to add a book to the library
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    // Method to get all books in the library
    public List<Book> GetBooks()
    {
        return books;
    }

    // Other methods for searching, removing books, etc.
}
