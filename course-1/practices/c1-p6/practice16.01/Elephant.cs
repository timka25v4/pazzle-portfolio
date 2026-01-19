using System;

public class Elephant : Animal
{
	public Elephant(string name) : base(name) { }
	public override void MakeSound()
	{
		ChangeEnergy(+10);
		Console.WriteLine($"Слон говорит: Тру-ууу-ррр! Энергия: {_energy}");
	}
}
