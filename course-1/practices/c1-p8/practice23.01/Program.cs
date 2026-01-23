using System;

public interface IPlayable
{
	void Play();
}

public class Guitar : IPlayable
{
	public void Play()
	{
		Console.WriteLine("Гитара играет аккорды");
	}
}

public class Piano : IPlayable
{
	public void Play()
	{
		Console.WriteLine("Пианино играет мелодию");
	}
}

public class Drum : IPlayable
{
	public void Play()
	{
		Console.WriteLine("Барабан отбивает ритм");
	}
}
public class Program
{
	static void Main()
	{
		IPlayable[] instruments =
		{
			new Guitar(),
			new Piano(),
			new Drum()
		};
		foreach (var i in instruments)
			i.Play();
		TextDocument doc = new TextDocument();
		doc.Read("data.txt");
		doc.Write("data.txt", "Привет, мир!");
		doc.Save();
		IDocumentExporter[] exporters =
		{
			new TxtExporter(),
			new PdfExporter()
		};

		foreach (var e in exporters)
		{
			e.ShowInfo("Hello World!");
			e.Export("Hello World!");
		}
	}
}