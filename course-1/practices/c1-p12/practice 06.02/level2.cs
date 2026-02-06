using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace practice11
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Library library = new()
            {
                Name = "Городская библиотека",
                Books = new List<Book>
                {
                        new Book { Title = "Война и мир", Author = "Толстой", Year = 1869 },
                        new Book { Title = "Преступление и наказание", Author = "Достоевский", Year = 1866 }
                }
           };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(library, options);
            File.WriteAllText("library.json", json);


            string jsonFromFile = File.ReadAllText("library.json");
            var libraryFromFile = JsonSerializer.Deserialize<Library>(jsonFromFile);

            Console.WriteLine($"Библиотека: {libraryFromFile.Name}");
            foreach (var b in libraryFromFile.Books)
            {
                Console.WriteLine($"Книга: \"{b.Title}\", автор: {b.Author}, год: {b.Year}");
            }
        }
    }
}