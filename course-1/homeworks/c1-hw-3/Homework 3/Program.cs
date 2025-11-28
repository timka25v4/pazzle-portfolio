using System;

internal class Program
{
    private static void Main(string[] args)
    {
        //Задание 5: Конвертер температуры
        double degree = double.Parse(Console.ReadLine());
        double F = degree * 9 / 5 + 32;
        Console.WriteLine(F);
        //Задание 6. Среднее арифметическое трёх чисел
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double avg = (a + b + c) / 3;
        Console.WriteLine("Среднее арифметическое чисел: " + avg.ToString());
        //Задание 7. Калькулятор
        double s1 = double.Parse(Console.ReadLine());
        double s2 = double.Parse(Console.ReadLine());
        double sum = s1 + s2;
        double dif = s1 - s2;
        double proizvedenie = s1 * s2;
        double chastnoe = s1 / s2;
        Console.WriteLine(sum.ToString(), dif.ToString(), proizvedenie.ToString(), chastnoe.ToString());
        //Задание 8. Конвертер валюты
        double rubles = double.Parse(Console.ReadLine());
        double dollars = rubles * 0.013;
        double yuan = rubles * 0.092; 
        double euro = rubles * 0.011;
        Console.WriteLine("Долларов " + dollars.ToString(), "Евро " + euro.ToString(), "Юаней " + yuan.ToString());
    }
}