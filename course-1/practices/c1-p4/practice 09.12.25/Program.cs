using System;
public class Car
{
	public string Brand { get; set; }
	public int Speed { get; set; }
	public void Accelerate() => Speed += 10;
}
public class Car1
{
	public string Brand { get; set; }
	public int Speed { get; set; }
	public Car1(string brand, int speed)
	{
		Brand = brand;
		Speed = speed;
	}
	public void Accelerate() => Speed += 10;
}
public class Book
{
	public string Title { get; set; }
	public string Author { get; set; }
	public int Pages { get; set; }
	public Book(string title, string author, int pages)
	{
		Title = "Назавние Книги";
		Author = "Имя Автора";
		Pages = pages;
	}
	public void Read(int pages)
	{
		Console.WriteLine($"Вы прочитали X страниц из {pages}");
	}
}
class Program
{
	static void Main()
	{   //Уровень 1
		//Задание 1-2
		var car = new Car {Brand = "BMW" };
		car.Accelerate();
		car.Accelerate();
		Console.WriteLine($"{car.Brand} едет со скоростью {car.Speed}");
		var car1 = new Car1 ( "Audi", 50 );
		//Задание 3-4
		//Класс Book
		//4 задание трудно было сделать(
	}
}

