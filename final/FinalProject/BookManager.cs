using System;
using System.Collections.Generic;
using System.Linq;

public class BookManager
{
    private List<Book> books;

    public BookManager()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public bool RemoveBook(Book book)
    {
        return books.Remove(book);
    }

    public List<Book> SearchByTitle(string title)
    {
        return books.Where(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Book> SearchByAuthor(string author)
    {
        return books.Where(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Book> SearchByGenre(string genre)
    {
        return books.Where(book => book.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public int TotalBooks => books.Count;
}
