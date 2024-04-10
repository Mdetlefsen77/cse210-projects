public class Book
{
    // Propiedades del libro
    public string Title { get; }
    public string Author { get; }
    public string Genre { get; }
    public int Year { get; }
    public int Popularity { get; set; } // Propiedad de popularidad

    // Constructor
    public Book(string title, string author, string genre, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
        Popularity = 0; 
    }

    
    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, Genre: {Genre}, Year: {Year}, Popularity: {Popularity}";
    }
}
