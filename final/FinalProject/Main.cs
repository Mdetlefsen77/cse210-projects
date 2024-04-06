using System;
using System.Collections.Generic;
using System.IO;

public class Main
{

    public void Start()
    {
        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 1925);
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "Fiction", 1960);

        // Create a library
        Library library = new Library();

        // Add books to the library
        library.AddBook(book1);
        library.AddBook(book2);

        // Example of basic interaction
        Console.WriteLine("Books in the library:");
        foreach (Book book in library.GetBooks())
        {
            Console.WriteLine($"- {book.Title} by {book.Author} ({book.Year})");
        }
    }

}