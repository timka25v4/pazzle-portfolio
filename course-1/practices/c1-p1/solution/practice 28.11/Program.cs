using System;
using System.Numerics;

class Program
{
	static void Main()
	{   //Уровень 1
		//Задание 1: Проверка числа
		int number = 10;
		if (number > 0)
		{
			Console.WriteLine("Число положительное");
		}
		else if (number < 0)
		{
			Console.WriteLine("Число отрицательное");
		}
		else
		{
			Console.WriteLine("Число равно нулю");
		}
		//Задание 2: Проверка возраста
		int age = int.Parse(Console.ReadLine());
		if (age >= 18)
		{
			Console.WriteLine("Вы совершеннолетний");
		}
		else
		{
			Console.WriteLine("Вы несовершеннолетний");
		}
		//Задание 3: Проверка чётности числа
		int num = 7;
		if (num % 2 == 0)
		{
			Console.WriteLine("Число чётное");
		}
		else
		{
			Console.WriteLine("Число нечётное");
		}
		//Уровень 2
		//Задание 4: Логические операторы
		int a = 5, b = -2;
		if (a > 0 && b > 0)
		{
			Console.WriteLine("Оба числа положительные");
		}
		else if (a > 0 || b > 0)
		{
			Console.WriteLine("Хотя бы одно число положительное");
		}
		if (a < 0)
		{
			Console.WriteLine("a не положительное");
		}
	}
}