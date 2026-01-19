using System;

public class Animal
{
	public string Name { get; set; }
	public int _energy { get; set; }
	public Animal(string name)
	{
		Name = name;
	}
	public Animal() : this("Неизвестный") { }
	public void Eat()
	{
		ChangeEnergy(+10);
		Console.WriteLine($"{Name} ест. Энергия: {_energy}");
	}

	public void Rest()
	{
		ChangeEnergy(+5);
		Console.WriteLine($"{Name} отдыхает. Энергия: {_energy}");
	}

	public virtual void MakeSound()
	{
		ChangeEnergy(-5);
		Console.WriteLine($"{Name} издаёт звук. Энергия: {_energy}");
	}

	public void ChangeEnergy(int delta)
	{
		_energy += delta;
		if (_energy < 0) _energy = 0;
		if (_energy > 150) _energy = 150;
	}
}
