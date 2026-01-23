using System;

public abstract class Shape
{
	public abstract string Name { get; }
	public abstract double GetArea();
	public void Print() => Console.WriteLine($"{Name}: площадь = {GetArea()}");
}
public class Circle : Shape
{
	public override string Name => "Круг";
	public int Radius => 10;
	public override double GetArea() => 3.14 * Radius * Radius;
}
public class Rectangle : Shape
{
	public override string Name => "Прямоугольник";
	public int Width => 10;
	public int Height => 10;
	public override double GetArea() => Width * Height;
}
class Program
{
	static void Main()
	{
		Shape[] shapes =
		{
		new Circle(),
		new Rectangle()
		};
		foreach (var k in shapes) k.Print();
	}	
}