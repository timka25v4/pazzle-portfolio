using System;

public class reservation
{
	public Book ReservedBook { get; set; }
	public Reader ReservedByPerson { get; set; }
	public DateTime ReservationDate { get; set; }
	public DateTime ExpirationDate { get; set; }

	public reservation(Book book, Reader reader, int days = 21)
	{
		ReservedBook = book;
		ReservedByPerson = reader;
		ReservationDate = DateTime.Now;
		ExpirationDate = DateTime.Now.AddDays(days);
	}
	public bool IfExpired => DateTime.Now > ExpirationDate;
}
