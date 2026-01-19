using System;

public class Program
{
	static void Main()
	{
		//var a1 = new Animal { Name = "Безымянный" };
		//a1.Eat();
		//a1.MakeSound();
		var a1 = new Animal();
		a1.Eat();
		a1.MakeSound();
		var a2 = new Animal("Мурка");          
		var a3 = new Animal { Name = "Шарик" };
		a1.Eat(); a2.Eat(); a3.Eat();
		var dog = new Dog("Шарик");
		Animal[] zoo =
			{
			new Dog("Шарик"),
			new Cat("Мурка"),
			new Elephant("Дамбо"),
			new Animal("Неопознанный")
			};
		foreach (var a in zoo)
		{
			a.MakeSound();
		}
		var zooPark = new Zoo(5);
		zooPark.Add(new Dog("Рекс"));
		zooPark.Add(new Cat("Снежок"));
		zooPark.Add(new Elephant("Балу"));

		Console.WriteLine("=== Звуки ===");
		zooPark.MakeAllSounds();

		Console.WriteLine("=== Кормим ===");
		zooPark.FeedAll();
	}
}
