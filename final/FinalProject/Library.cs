public class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public List<Book> SearchBooksByTitle(string title)
    {
        List<Book> foundBooks = new List<Book>();
        foreach (var book in books)
        {
            if (book.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            {
                foundBooks.Add(book);
            }
        }
        return foundBooks;
    }

    public List<Book> SearchBooksByAuthor(string author)
    {
        List<Book> foundBooks = new List<Book>();
        foreach (var book in books)
        {
            if (book.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
            {
                foundBooks.Add(book);
            }
        }
        return foundBooks;
    }

    public List<Book> SearchBooksByGenre(string genre)
    {
        List<Book> foundBooks = new List<Book>();
        foreach (var book in books)
        {
            if (book.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase))
            {
                foundBooks.Add(book);
            }
        }
        return foundBooks;
    }

    public List<Book> GetAllBooks()
    {
        return books;
    }
}