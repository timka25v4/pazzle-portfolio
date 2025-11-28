using System;
using System.ComponentModel;

class Program
{
	static void Main()
	{   //Уровень 2
		//Задание 5: Калькулятор оценок
		int grade = int.Parse(Console.ReadLine());
		if (grade == 3)
		{
			Console.WriteLine("Удовлетворительно");
		}
		else if (grade == 4)
		{
			Console.WriteLine("Хорошо");
		}
		else if (grade == 5)
		{
			Console.WriteLine("Отлично");
		}
		//Задание 6: Калькулятор
		double a = double.Parse(Console.ReadLine());
		double b = double.Parse(Console.ReadLine());
		string command = Console.ReadLine();
		if (command == "+")
		{
			Console.WriteLine(a + b);
		}
		else if (command == "-")
		{
			Console.WriteLine(a - b);
		}
		else if (command == "*")
		{
			Console.WriteLine(a * b);
		}
		else if (command == "/")
		{
			Console.WriteLine(a / b);
		}
		//Задание 7: Проверка пароля
		string password = 'drowssap';
		string user_pass = Console.ReadLine();
		if (password == user_pass)
		{
			Console.WriteLine("Доступ получен");
		}
		else
		{
			Console.WriteLine("Доступ запрещён");
		}
	}
}