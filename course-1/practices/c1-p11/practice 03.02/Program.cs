using System.IO;
using System;
using System.Text;

string path = "notes.txt";
File.WriteAllLines(path, new[]
{
	"Заметка 1",
	"Заметка 2",
	"Заметка 3"
});

using (var writer = new StreamWriter(path, append: true))
{
	writer.WriteLine($"Заметка 4");
}

using (var reader = new StreamReader(path, Encoding.UTF8))
{
	string content = reader.ReadToEnd();
	Console.WriteLine(content);
}

Console.WriteLine("Нажмите y, чтобы удалить файл");

string input = Console.ReadLine();

if (input == "y")
{
	if (File.Exists(path))
	{
		File.Delete(path);
		Console.WriteLine("Файл удалён");
	}
	else
	{
		Console.WriteLine("Файл не найден");
	}
}

string directoryPath = "data";

Directory.CreateDirectory(directoryPath);

Console.WriteLine($"Каталог '{directoryPath}' создан или уже был создан.");

File.WriteAllText(Path.Combine(directoryPath, "file1.txt"), "Текстовый файл 1");
File.WriteAllText(Path.Combine(directoryPath, "file2.txt"), "Текстооооооооовый файлллллллл 2");
File.WriteAllText(Path.Combine(directoryPath, "file3.txt"), "Текстовейший файл 3");

DirectoryInfo directory = new DirectoryInfo(directoryPath);

FileInfo[] files = directory.GetFiles();

foreach (FileInfo file in files)
{

	Console.WriteLine($"Файл: {file.Name}, Размер: {file.Length} байт.");
}

Console.WriteLine("Введите путь к файлу: ");

string originPath = Console.ReadLine();

if (File.Exists(originPath))
{
	string backPath = originPath + ".bak";
	File.Copy(originPath, backPath, true);
	Console.WriteLine($"Резервная копия успешно создана: {backPath}");
}
else
{
	Console.WriteLine("Ошибка: Указанный файл не существует.");
}
string logDirectory = "logs";

Directory.CreateDirectory(logDirectory);

string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
string fullPath = Path.Combine(logDirectory, fileName);

string logMessage = $"{DateTime.Now:HH:mm:ss} - время лога";

File.AppendAllText(fullPath, logMessage + Environment.NewLine);

Console.WriteLine($"Записано в файл: {fullPath}");

DateTime threeDaysAgo = DateTime.Now.AddDays(-3);

DirectoryInfo di = new DirectoryInfo(logDirectory);

FileInfo[] files1 = di.GetFiles();

foreach (FileInfo file in files1)
{
	if (file.LastWriteTime < threeDaysAgo)
	{
		File.Delete(file.FullName);
		Console.WriteLine($"Удален старый лог: {file.Name} (дата: {file.LastWriteTime:yyyy-MM-dd})");
	}
}

Console.WriteLine("Очистка завершена.");