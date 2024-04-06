public class Reader : User
{
    // Lists of read, reading, and desired books
    private List<Book> readBooks;
    private List<Book> readingBooks;
    private List<Book> desiredBooks;

    // Constructor
    public Reader(string name, string email) : base(name, email)
    {
        readBooks = new List<Book>();
        readingBooks = new List<Book>();
        desiredBooks = new List<Book>();
    }

    // Method to add a read book
    public void AddReadBook(Book book)
    {
        readBooks.Add(book);
    }

    // Other methods to manage reading and desired books
}

