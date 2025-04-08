using System;
using System.Collections.Generic;
public interface IBook
{
    string Title { get; set; }
    string Author { get; set; }
}
public class Book : IBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
    public override string ToString() => "Название: " + Title + " Автор: " + Author;
}
public class Library
{
    public List<IBook> books = new List<IBook>();
    public Library()
    {
        List<IBook> books = new List<IBook>();
    }
    public void AddBook(IBook book)
    {
        books.Add(book);
        Console.WriteLine($"Книга '{book.Title}' {book.Author} добавлена");
    }
    public void RemoveBook(string title, string author)
    {
        IBook book = FindBookByTitle(title);
        if (book != null && book.Title == title && book.Author == author)
        {
            books.Remove(book);
            Console.WriteLine($"Книга '{book.Title}' {book.Author} удалена");
        }
        else
        {
            Console.WriteLine($"Книга '{title}' {author} не найдена");
        }
    }
    public IBook FindBookByTitle(string title)
    {
        foreach (IBook book in books)
        {
            if (book.Title == title)
            {
                return book;
            }
        }
        return null;
    }
    public List<IBook> FindBooksByAuthor(string author)
    {
        var result = new List<IBook>();
        foreach (IBook book in books)
        {
            if (book.Author == author)
            {
                result.Add(book);
            }
        }
        return result;
    }
}
public class Program
{
    public static void Main()
    {
        Library library = new Library();
        library.AddBook(new Book("Ходячий замок", "Анна Хэтуэй"));
        int n = 1;
        Console.WriteLine("1-добавить книгу; 2-удалить книгу; 3-поиск по названию; 4-поиск по автору; 0-выход");
        while (n != 0)
        {
            Console.WriteLine("Выбирете действие: ");
            n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 0: break;
                case 1:
                    {
                        Console.WriteLine("Введите название книги ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите автора книги ");
                        string aut = Console.ReadLine();
                        library.AddBook(new Book(name, aut));
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Введите название книги ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите автора книги ");
                        string aut = Console.ReadLine();
                        library.RemoveBook(name, aut);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Введите название книги ");
                        string name = Console.ReadLine();
                        IBook book = library.FindBookByTitle(name);
                        if (book != null)
                        {
                            Console.WriteLine(book.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Книга с таким названием не найдена");
                        }
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Введите автора книги ");
                        string aut = Console.ReadLine();
                        List<IBook> bookss = library.FindBooksByAuthor(aut);
                        if (bookss.Count > 0)
                        {
                            Console.WriteLine($"Книги {aut}: ");
                            foreach (IBook book in bookss)
                            {
                                Console.WriteLine(book.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Книги с таким автором не найдены");
                        }
                        break;
                    }
                default: Console.WriteLine("Неправильно набрано действие"); break;
            }
        }
    }
}
