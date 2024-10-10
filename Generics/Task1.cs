using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

class Book
{
    private LinkedList<Book> books = new LinkedList<Book>();
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    public Book()
    {

    }
    public Book(string title, string author, string genre, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
    }

    public void AddBook(Book book)
    {
        books.AddLast(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }
    public void UpdateBook(Book oldBook, Book newBook)
    {
        var node = books.Find(oldBook);
        if (node != null)
        {
            node.Value = newBook;
        }
    }
    public void InsertBookAtStart(Book book)
    {
        books.AddFirst(book);
    }

    public void InsertBookAtEnd(Book book)
    {
        books.AddLast(book);
    }
    public string? FindBookByTitle(string title)
    {
        foreach (var book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                return book.Title;
            }
        }
        return null;
    }
    public void InsertBookAtPosition(Book book, int position)
    {
        if (position < 0 || position > books.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        var node = books.First;
        for (int i = 0; i < position; i++)
        {
            node = node.Next;
        }

        books.AddBefore(node, book);
    }
    public void RemoveBookAtPosition(int position)
    {
        if (position < 0 || position >= books.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        var node = books.First;
        for (int i = 0; i < position; i++)
        {
            node = node.Next;
        }

        books.Remove(node);
    }
    public void RemoveBookFromStart()
    {
        if (books.First != null)
        {
            books.RemoveFirst();
        }
    }
    public void RemoveBookFromEnd()
    {
        if (books.Last != null)
        {
            books.RemoveLast();
        }
    }
    public void PrintAllBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
}

class Task1
{
    public void Task()
    {
        Book books = new Book();
        var book1 = new Book("Название1", "Автор1", "Жанр1", 2002);
        books.AddBook(book1);
        books.PrintAllBooks();
        var book2 = new Book("Название2", "Автор2", "Жанр2", 2002);
        books.InsertBookAtStart(book2);
        books.PrintAllBooks();
        books.RemoveBookFromEnd();
        books.PrintAllBooks();
    }
}












