public class UserInterface
{
    // Method to display a menu and get user selection
    public int ShowMenuAndGetSelection()
    {
        // Logic to display the menu and get user selection
        // This is a sample implementation; you can adapt it as needed
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. Search Books");
        Console.WriteLine("3. View Reading History");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice: ");
        int selection = Convert.ToInt32(Console.ReadLine());
        return selection;
    }

    // Other methods for interacting with the user, displaying messages, etc.
}
