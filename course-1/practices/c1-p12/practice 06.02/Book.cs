using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

var books = new List<Book>
{
	new Book { Title = "Война и мир", Author = "Толстой", Year = 1869 },
	new Book { Title = "Преступление и наказание", Author = "Достоевский", Year = 1866 }
};

string json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("books.json", json);

string jsonFromFile = File.ReadAllText("books.json");
var booksFromFile = JsonSerializer.Deserialize<List<Book>>(jsonFromFile);

foreach (var book in booksFromFile)
{
	Console.WriteLine($"Название: {book.Title}, Автор: {book.Author}, Год: {book.Year}");
}

var options = new JsonSerializerOptions { WriteIndented = true };
string json1 = JsonSerializer.Serialize(books, options);
File.WriteAllText("books.json", json1);
