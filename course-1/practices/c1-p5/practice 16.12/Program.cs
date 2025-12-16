using System;
class Program
{
	public class Animal
	{
		public string Name { get; set; }
		public void Eat()
		{
			Console.WriteLine($"{Name} ест.");
		}
		public virtual void Speak()
		{
			Console.WriteLine("Животное издаёт звук");
		}
		public virtual void Move()
		{
			Console.WriteLine($"Животное двигается.");
		}
		public Animal(string name)
		{
			Name = name;
			Console.WriteLine($"Создано животное: {Name}");
		}
	}
	//public class Dog : Animal
	//{
	//	public void Bark()
	//	{
	//		Console.WriteLine($"{Name} лает.");
	//	}
 //       public override void Speak()
 //       {
	//		Console.WriteLine("Собака говорит: Гав-гав!");
 //       }
	//	public override void Move()
	//	{
	//		base.Move();
	//		Console.WriteLine($"Собака бежит по дороге.");
	//	}
	//}
	public class Cat : Animal
	{
		public void Meow()
		{
			Console.WriteLine($"{Name} мяукает");
		}
		public override void Speak()
		{
			Console.WriteLine("Кошка говорит: Мяу!");
		}
		public override void Move()
		{
			base.Move();
			Console.WriteLine($"Кошка бежит по дороге.");
		}
		public Cat(string name) : base(name)
		{
			Console.WriteLine($"Создана кошка по имени {Name}");
		}
	}
	public class Transport
	{
		public virtual void Drive()
		{
			Console.WriteLine("Транспорт движется");
		}
	}
	public class Car : Transport
	{
        public override void Drive()
        {
			Console.WriteLine("Машина едет по дороге");
        }
	}
	public class ElectricCar : Car
	{
        public override void Drive()
        {
			Console.WriteLine("Электромобиль тихо едет на батарее");
        }
	}
	static void Main()
	{
		//var dog = new Dog();
		//dog.Name = "Шарик";
		//dog.Eat();
		//dog.Bark();
		//var cat = new Cat();
		//cat.Name = "Мурка";
		//cat.Eat();
		//cat.Meow();
		//dog.Speak();
		//cat.Speak();
		//dog.Move();
		//cat.Move();
		var cat = new Cat("Мурка");
		var transport = new Transport();
		var car = new Car();
		var tesla = new ElectricCar();
		transport.Drive();
		car.Drive();
		tesla.Drive();
	}

}