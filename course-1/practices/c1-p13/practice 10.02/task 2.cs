using System;
using System.Linq;
using System.Collections.Generic;

namespace task2
{
	public record Student(string Name, int Grade);

	class Program
	{
		static void Main(string[] args)
		{
			var students = new List<Student>
			{
				new("Аня",5), new("Борис",3), new("Вика",4), new("Гена",4), new("Дана",5)
			};

			var bestNames = students
				.Where(s => s.Grade >= 4)
				.OrderBy(s => s.Name)
				.Select(s => s.Name);

			Console.WriteLine("Имена учеников с оценкой >= 4:");
			foreach (var name in bestNames)
			{
				Console.WriteLine(name);
			}


			bool GreatestStudents = students.Any(s => s.Grade == 5);


			Console.WriteLine($"Отличники: {GreatestStudents}");



		}
	}
}