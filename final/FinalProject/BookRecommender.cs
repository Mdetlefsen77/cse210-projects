using System;
using System.Collections.Generic;
using System.Linq;

public class BookRecommender
{
    private Library library;

    // Constructor
    public BookRecommender(Library library)
    {
        this.library = library;
    }

    // Método para recomendar libros basados en el historial de lectura del usuario
    public List<Book> RecommendBooks(Reader reader)
    {
        // Obtener todos los libros de la biblioteca
        List<Book> allBooks = library.GetAllBooks();

        // Obtener los libros leídos por el usuario
        List<Book> readBooks = reader.GetReadBooks();

        // Calcular la popularidad de los libros no leídos
        var unreadBooks = allBooks.Where(book => !readBooks.Contains(book))
                                  .OrderByDescending(book => book.Popularity)
                                  .Take(5)
                                  .ToList();

        return unreadBooks;
    }
}