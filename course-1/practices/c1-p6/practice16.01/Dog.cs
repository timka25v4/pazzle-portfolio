using System;
public class Dog : Animal
{
	public Dog(string name) : base(name) { }
    public override void MakeSound()
    {
		Console.WriteLine($"Собака говорит: Гав-гав! Энергия: {_energy}");
	}
}
