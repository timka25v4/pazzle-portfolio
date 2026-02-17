using System;
using System.Linq;
using System.Collections.Generic;

namespace task3
{
	class Program
	{
		static void Main(string[] args)
		{
			var dates = new List<DateTime>
			{
				new(2025,1,10), new(2025,1,25), new(2025,2,3),
				new(2025,2,28), new(2025,2,15), new(2025,3,1)
			};

			var results = dates
				.GroupBy(d => d.Month)
				.Select(g => new
				{
					Month = g.Key,
					Count = g.Count(),
					MinDate = g.Min(),
					MaxDate = g.Max()
				});
			foreach (var item in results)
			{
				Console.WriteLine(($"Месяц: {item.Month}, Количество: {item.Count}, " +
							 $"Мин: {item.MinDate:yyyy-MM-dd}, Макс: {item.MaxDate:yyyy-MM-dd}"));
			}
		}
	}
}