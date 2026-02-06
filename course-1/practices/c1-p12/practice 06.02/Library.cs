using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Library
{
	public string Name { get; set; }
	public List<Book> Books { get; set; }
}

public class Book
{
	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("author")]
	public string Author { get; set; }

	[JsonPropertyName("publication_year")]
	public int Year { get; set; }
}
