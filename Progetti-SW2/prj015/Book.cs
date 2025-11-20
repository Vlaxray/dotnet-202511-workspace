using System;
using Microsoft.VisualBasic;
public class Book
{
    public string Isbn { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }

    public Book() : this("10000123", "C# Programming", 1984) { }//default constructor
    public Book(string isbn, string title, int year)//parametrizzato constructor
    {
        this.Isbn = isbn;
        this.Title = title;
        this.Year = year;
    }
    public Book(string isbn, string title)
            : this(isbn, title, 2016) { }
    public override string ToString()
    {
        return this.Isbn + "\t" + this.Title + "\t" + this.Year.ToString();
    }
}