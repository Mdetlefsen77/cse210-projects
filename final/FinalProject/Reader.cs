public class Reader : User
{
    private List<Book> readBooks;
    private List<Book> readingBooks;
    private List<Book> desiredBooks;

    public Reader(string name, string email) : base(name, email)
    {
        readBooks = new List<Book>();
        readingBooks = new List<Book>();
        desiredBooks = new List<Book>();
    }

    public void AddReadBook(Book book)
    {
        book.Popularity++;
        readBooks.Add(book);
    }

    public void AddReadingBook(Book book)
{
    if (!readingBooks.Contains(book))
    {
        readingBooks.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to reading list.");
    }
    else
    {
        Console.WriteLine($"Book '{book.Title}' is already in the reading list.");
    }
}

public void AddDesiredBook(Book book)
{
    if (!desiredBooks.Contains(book))
    {
        desiredBooks.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to desired list.");
    }
    else
    {
        Console.WriteLine($"Book '{book.Title}' is already in the desired list.");
    }
}


 public void DisplayReadBooks()
{
    if (readBooks.Count == 0)
    {
        Console.WriteLine("No books have been read yet.");
    }
    else
    {
        Console.WriteLine("Read Books:");
        foreach (var book in readBooks)
        {
            Console.WriteLine(book);
        }
    }
}

public void DisplayReadingBooks()
{
    if (readingBooks.Count == 0)
    {
        Console.WriteLine("No books are currently being read.");
    }
    else
    {
        Console.WriteLine("Reading Books:");
        foreach (var book in readingBooks)
        {
            Console.WriteLine(book);
        }
    }
}

public void DisplayDesiredBooks()
{
    if (desiredBooks.Count == 0)
    {
        Console.WriteLine("No desired books yet.");
    }
    else
    {
        Console.WriteLine("Desired Books:");
        foreach (var book in desiredBooks)
        {
            Console.WriteLine(book);
        }
    }
}


    public List<Book> GetReadBooks()
    {
        return readBooks;
    }
}
