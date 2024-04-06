public class BookManager
{
    // List of books in the library
    private List<Book> books;
    // Constructor
    public BookManager()
    {
        books = new List<Book>();
    }
    // Method to add a book to the library
    public void AddBook(Book book)
    {
        books.Add(book);
    }
    // Other methods for searching, removing books, etc.
}
