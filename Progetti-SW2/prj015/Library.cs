using System.Collections.Generic;
public class Library
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Book> Books { get; set; }
    public Library(string name, string address)
    {
        this.Name = name;
        this.Address = address;
        this.Books = new List<Book>();
    }
    public Library() : this("Default", "Default") { }
    public void AddBook(Book book)
    {
        if (Books == null)
            return;
        Books.Add(book);
    }
    public void BorrowBook(Book Book)
    {
        if (this.Books.Count > 0)
            this.Books.RemoveAt(0);
    }
    public void ShowAllOrders()
    {
        foreach (Book book in this.Books)
            System.Console.WriteLine(book);
    }
}
