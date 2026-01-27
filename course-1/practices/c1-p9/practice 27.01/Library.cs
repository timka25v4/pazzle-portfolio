using System;

public class Library : ILibraryManagement
{
	private List<Book> _books = new List<Book>();
	private List<reservation> _reservations = new List<reservation>();

	public void CreateReservation(Book book, Reader reader)
	{
		if (_reservations.Any(r => r.ReservedBook == book && !r.IfExpired))
		{
			Console.WriteLine("Книга уже зарезервирована.");
			return;
		}
		var newReservation = new reservation(book, reader);
		_reservations.Add(newReservation);
		Console.WriteLine($"Книга '{book.Title}' зарезервирована для {reader.Name} до {newReservation.ExpirationDate.ToShortDateString()}.");
	}

	public void CancelReservation(Book book, Reader reader)
	{
		var reservation = _reservations.FirstOrDefault(r => r.ReservedBook == book && r.ReservedByPerson == reader);
		if (reservation != null)
		{
			_reservations.Remove(reservation);
			Console.WriteLine("Резервирование отменено.");
		}
	}

	public void ClearExpiredReservations()
	{
		_reservations.RemoveAll(r => r.IfExpired);
	}

	public void AddBook(Book book)
	{
		_books.Add(book);
		Console.WriteLine($"Книга \"{book.Title}\" добавлена в библиотеку.");
	}

	public bool RemoveBook(Book book)
	{
		bool removed = _books.Remove(book);
		if (removed)
			Console.WriteLine($"Книга \"{book.Title}\" удалена из библиотеки.");
		return removed;
	}

	public List<Book> SearchByAuthor(string author)
	{
		return _books.Where(b => b.Author == author).ToList();
	}

	public void ListBooks()
	{
		Console.WriteLine("Список книг в библиотеке:");
		foreach (var book in _books)
		{
			book.ShowInfo();
		}
	}

	public void IssueBook(Book book, Reader reader)
	{
		if (_books.Contains(book))
		{
			reader.BorrowBook(book);
			_books.Remove(book);
		}
		else
		{
			Console.WriteLine($"Книга \"{book.Title}\" сейчас недоступна.");
		}
	}

	public void ReturnBook(Book book)
	{
		_books.Add(book);
		Console.WriteLine($"Книга \"{book.Title}\" возвращена в библиотеку.");
	}

}

