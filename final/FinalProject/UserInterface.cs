using System;
using System.Collections.Generic;


public class UserInterface
{
    private Library library;
    private Reader reader;


    public UserInterface(Library library, Reader reader)
    {
        this.library = library;
        this.reader = reader;

        ShowMenu();
    }


    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("Welcome to Virtual Library!");
            Console.WriteLine();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Search Books by Title");
            Console.WriteLine("2. Search Books by Author");
            Console.WriteLine("3. Search Books by Genre");
            Console.WriteLine("4. Add Book to Library");
            Console.WriteLine("5. Mark as Readed");
            Console.WriteLine("6. Show Read Books");
            Console.WriteLine("7. Add Book to Reading List");
            Console.WriteLine("8. Show Reading Books");
            Console.WriteLine("9. Add Book to Desired List");
            Console.WriteLine("10. Show Desired Books");
            Console.WriteLine("11. Get Book Recommendations");
            Console.WriteLine("12. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    SearchBooksByTitle();
                    break;
                case 2:
                    SearchBooksByAuthor();
                    break;
                case 3:
                    SearchBooksByGenre();
                    break;
                case 4:
                    AddBook();
                    break;
                case 5:
                    MarkBookAsRead();
                    break;
                case 6:
                    reader.DisplayReadBooks();
                    break;
                case 7:
                    AddBookToReadingList();
                    break;
                case 8:
                    reader.DisplayReadingBooks();
                    break;
                case 9:
                    AddBookToDesiredList();
                    break;
                case 10:
                    reader.DisplayDesiredBooks();
                    break;
                case 11:
                    GetBookRecommendations();
                    break;
                case 12:
                    Console.WriteLine("Exiting. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }


    private void SearchBooksByTitle()
    {
        Console.Write("Enter the title to search: ");
        string title = Console.ReadLine();
        var foundBooks = library.SearchBooksByTitle(title);
        DisplaySearchResults(foundBooks);
    }


    private void SearchBooksByAuthor()
    {
        Console.Write("Enter the author to search: ");
        string author = Console.ReadLine();
        var foundBooks = library.SearchBooksByAuthor(author);
        DisplaySearchResults(foundBooks);
    }


    private void SearchBooksByGenre()
    {
        Console.Write("Enter the genre to search: ");
        string genre = Console.ReadLine();
        var foundBooks = library.SearchBooksByGenre(genre);
        DisplaySearchResults(foundBooks);
    }


    private void AddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        Console.Write("Enter book author: ");
        string author = Console.ReadLine();
        Console.Write("Enter book genre: ");
        string genre = Console.ReadLine();
        Console.Write("Enter publication year: ");
        int year;
        if (!int.TryParse(Console.ReadLine(), out year))
        {
            Console.WriteLine("Invalid year. Please enter a valid number.");
            return;
        }
        Book book = new Book(title, author, genre, year);
        library.AddBook(book);
        Console.WriteLine("Book added successfully!");
    }


    private void DisplaySearchResults(List<Book> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books found.");
            return;
        }

        Console.WriteLine("Search Results:");
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }

    public void MarkBookAsRead()
    {
        Console.Write("Enter the title of the book you want to mark as read: ");
        string title = Console.ReadLine();

        List<Book> foundBooks = library.SearchBooksByTitle(title);
        if (foundBooks.Count == 0)
        {
            Console.WriteLine("Book not found in the library.");
            return;
        }
        Book selectedBook = foundBooks[0];
        reader.AddReadBook(selectedBook);
        Console.WriteLine($"Book '{selectedBook.Title}' marked as read.");
    }

    public void AddBookToReadingList()
    {
        Console.Write("Enter the title of the book you want to add to your reading list: ");
        string title = Console.ReadLine();

        List<Book> foundBooks = library.SearchBooksByTitle(title);
        if (foundBooks.Count == 0)
        {
            Console.WriteLine("Book not found in the library.");
            return;
        }
        Book selectedBook = foundBooks[0];
        reader.AddReadingBook(selectedBook);
        Console.WriteLine($"Book '{selectedBook.Title}' added to your reading list.");
    }

    public void AddBookToDesiredList()
    {
        Console.Write("Enter the title of the book you want to add to your desired list: ");
        string title = Console.ReadLine();

        List<Book> foundBooks = library.SearchBooksByTitle(title);
        if (foundBooks.Count == 0)
        {
            Console.WriteLine("Book not found in the library.");
            return;
        }
        Book selectedBook = foundBooks[0];
        reader.AddDesiredBook(selectedBook);
        Console.WriteLine($"Book '{selectedBook.Title}' added to your desired list.");
    }


    private void GetBookRecommendations()
    {
        var recommendations = new BookRecommender(library).RecommendBooks(reader);
        if (recommendations.Count == 0)
        {
            Console.WriteLine("No recommendations available.");
            return;
        }

        Console.WriteLine("Recommended Books:");
        foreach (var book in recommendations)
        {
            Console.WriteLine(book);
        }
    }
}
