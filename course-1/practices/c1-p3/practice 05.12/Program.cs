using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
class Program
{
	static void Main()
	{
		Console.WriteLine("Задание 1");
		void SayHello()
		{
			Console.WriteLine("Привет, мир!");
		}
		SayHello();
		SayHello();
		SayHello();
		Console.WriteLine("Задание 2");
		void Greet(string name)
		{
			Console.WriteLine($"Привет, {name}!");
		}
		Greet("Саша");
		Greet("Ярослав");
		Greet("Анна");
		Console.WriteLine("Задание 3");
		void PrintPerson(string name, int age, string city)
		{
			Console.WriteLine($"Имя: {name} Возраст: {age} Город: {city}");
		}
		PrintPerson("Егор", 15, "Москва");
		PrintPerson("Иван", 14, "Санкт-Петербург");
		PrintPerson("Ммхаил", 17, "Магнитогорск");
		Console.WriteLine("Задание 4");
		void PrintPersonInformation(string name, int age = 18, string hobby = "Не указано")
		{
			Console.WriteLine($"Name: {name} Возраст: {age} Хобби: {hobby}");
		}
		PrintPersonInformation("Егор", 17, "Рисование");
		Console.WriteLine("Задание 5");
		int Square(int x)
		{
			int square = x * x;
			return square;
		}

		int result = Square(6);
		Console.WriteLine("Квадрат числа: " + result);
		Console.WriteLine("Задание 6");
		int Add(int a, int b)
		{
			return a + b;
		}
		int Subtract(int a, int b)
		{
			return a - b;
		}
		int Multiply(int a, int b)
		{
			return a * b;
		}
		int Divide(int a, int b)
		{
			if (b == 0)
			{
				Console.WriteLine("Деление на 0");
				return 0;
			}
			else
			{
				return a / b;
			}
		}
		Console.WriteLine("Введите первое число:");
		string a1 = Console.ReadLine();
		Console.WriteLine("Введите второе число:");
		string b1 = Console.ReadLine();
		Console.WriteLine("Введите знак желаемой операции");
		string method = Console.ReadLine();
		int a = int.Parse(a1);
		int b = int.Parse(b1);
		Console.WriteLine("Результат операции: ");
		if (method == "+")
		{
			Console.WriteLine(Add(a, b));
		}
		else if (method == "-")
		{
			Console.WriteLine(Subtract(a, b));
		}
		else if (method == "/")
		{
			Console.WriteLine(Divide(a, b));
		}
		else if (method == "*")
		{
			Console.WriteLine(Multiply(a, b));
		}
		else
		{
			Console.WriteLine("Что-то пошло не так");
		}
		Console.WriteLine("Задание 7");
		int counter = 0;
		void Increment()
		{
			counter++;
		}
		Increment();
		Console.WriteLine(counter);
		Increment();
		Console.WriteLine(counter);
		Increment();
		Console.WriteLine(counter); 
		Increment();
		Console.WriteLine(counter);
		Console.WriteLine("Задание 8");
		//int Multiply(int a, int b)
		//{
		//	return a * b;
		//}
		//int Multiply(int a, int b, int c)
		//{
		//	return a * b * c;
		//}
		//double Multiply(double a, double b)
		//{
		//	return a * b;
		//}
		//Console.WriteLine(Multiply(2.5, 4.0));
		//Console.WriteLine(Multiply(2, 3));
		//Console.WriteLine(Multiply(2, 3, 4));
		Console.WriteLine("Не хочет выполнять восьмое задание, выводит ошибку, перегрузка невозможна.");
	}
}