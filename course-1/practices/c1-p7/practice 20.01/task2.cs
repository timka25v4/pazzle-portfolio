using System;

public abstract class Animal
{
	public string Name { get; }

	protected Animal(string name)
	{
		Name = name;
		Console.WriteLine($"Создано животное: {Name}");
	}
	public void Eat() => Console.WriteLine($"{Name} ест.");
	public abstract void MakeSound();
}
}
