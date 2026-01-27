using System;
class Program
{
	static void Main()
	{
		Library library = new Library();

		Textbook t1 = new Textbook("Математика 101", "Иванов", 2020, 300, "Математика");
		FictionBook f1 = new FictionBook("Война и мир", "Толстой", 1869, 1200, "Роман");

		library.AddBook(t1);
		library.AddBook(f1);
		library.ListBooks();

		Reader reader = new Reader("Алексей", 1);

		library.IssueBook(t1, reader);
		reader.ShowBorrowedBooks();

		library.ListBooks();

		library.ReturnBook(t1);
		library.ListBooks();

		Publication pub = new BookPublication(f1);
		pub.GetInfo();

	}
}

