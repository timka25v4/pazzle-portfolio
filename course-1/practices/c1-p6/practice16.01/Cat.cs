using System;

public class Cat : Animal
{
	public Cat(string name) : base(name) { }
	public override void MakeSound()
    {
		ChangeEnergy(+10);
		Console.WriteLine($"Кошка говорит: Мяу! Энергия: {_energy}");
	}
}
