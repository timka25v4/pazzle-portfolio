using System;
using System.ComponentModel.DataAnnotations;
class Program
{
	static void Main()
	{   //Уровень 1
		//Задание 1
		int[] massive = { 5, 8, 6, 7, 2 };
		for (int i = 0; i < massive.Length; i++)
		{
			Console.WriteLine(massive[i]);
		}
		//Задание 2
		int[] marks = { 4, 2, 3, 4, 5, 2 };
		int sum = 0;
		for (int i = 0; i < marks.Length; i++)
		{
			sum += marks[i];
		}
		Console.WriteLine(sum/6);
		//Задание 3
		int[] massive1 = { 67, 11, 32, 85, 96, 32, 47, 61 };
		int max = 0;
		for (int i = 0; i < massive1.Length; i++)
		{
			if (massive1[i] > 0)
			{
				max = i;
			}
		}
		Console.WriteLine(max);
		//Задание 4
		string[] fruits = { "Банан", "Груша", "Ананас", "Яблоко", "Виноград" };
		foreach (string fruit in fruits)
		{
			Console.WriteLine("Фрукт" + fruit);
		}
		//Уровень 2
		//Задание 5
		int[,] massive2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
		Console.WriteLine((massive2[0, 0], massive2[0, 1], massive2[0, 2]));
		Console.WriteLine((massive2[1, 0], massive2[1, 1], massive2[1, 2]));
		Console.WriteLine((massive2[2, 0], massive2[2, 1], massive2[2, 2]));
		//Без понятния, как по-другому сделать(
		//Задание 6

		string password = Console.ReadLine();
		string truepass = "1234";
		do
		{
			password = Console.ReadLine();
		}
		while (password != truepass);
	}
}