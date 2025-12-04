using System;

class Program
{
	static void Main()
	{   //Уровень 1
		Console.WriteLine("Задание 1");
		int[] grades = { 4, 3, 5, 2, 3, 4, 5 };
		int avg = 0;
		int c2 = 0;
		int c5 = 0;
		for (int i = 0; i < grades.Length; i++)
		{
			avg += grades[i];

			if (grades[i] == 5)
			{
				c5++;
			}
			else if (grades[i] == 2)
			{
				c2++;
			}
		}
		Console.WriteLine((float)avg / grades.Length);
		Console.WriteLine(c5);
		Console.WriteLine(c2);
		Console.WriteLine("Задание 2");
		int[] massive = { 1, 2, 3, 4, 5 };
		for (int i = 0; i < massive.Length; i++)
		{
			Console.WriteLine(massive[i]);
		}
		for (int i = massive.Length - 1; i >= 0; i--)
		{
			Console.WriteLine(massive[i]);
		}
		//Уровень 2
		Console.WriteLine("Задание 3");
		for (int i = 1; i <= 20; i++)
		{
			if (i % 2 == 1)
			{
				continue;
			}
			Console.WriteLine(i);
		}
		Console.WriteLine("Задание 4");
		int tries = 3;
		string password = "";
		do
		{
			password = Console.ReadLine();
			if (password == "1234")
			{
				Console.WriteLine("Доступ разрешён");
				break;
			}
			else
			{
				tries -= 1;
			}
			Console.WriteLine("Осталось попыток: " + tries.ToString());
		}
		while (tries != 0);
		if (tries == 0)
		{
			Console.WriteLine("Доступ запрещён");
		}
	}
}