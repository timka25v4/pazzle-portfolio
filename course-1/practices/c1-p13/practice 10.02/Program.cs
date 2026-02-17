using System;
using System.Linq;
using System.Collections.Generic;

int[] nums = { -3, -1, 0, 2, 4, 5, 6, 10, 12 };

var Nums = nums
	.Where(n => n > 0 && n % 2 == 0)
	.Select(n => n * n)
	.ToList();

int sum = Nums.Sum();
int count = Nums.Count();
double average = Nums.Average();

Console.WriteLine($"Сумма: {sum}");
Console.WriteLine($"Количество: {count}");
Console.WriteLine($"Среднее значение: {average}");
