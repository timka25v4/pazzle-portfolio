using System.Text.Json;
using System.Text.RegularExpressions;

public class JsonScheduleRepository : IScheduleRepository
{
	private readonly string _path;
	private readonly JsonSerializerOptions _opts = new() { PropertyNameCaseInsensitive = true };

	public JsonScheduleRepository(string path)
	{
		_path = path;
		if (!File.Exists(_path))
		{
			var sample = new ScheduleFile
			{
				Groups = new List<GroupSchedule>
			   {
				   new GroupSchedule
				   {
					   Group = "9А",
					   Days = new List<DaySchedule>
					   {
						   new DaySchedule { Day = "Monday", Lessons = new List<Lesson> { new Lesson("08:00","Math","Ivanov") } },
						   new DaySchedule { Day = "Tuesday", Lessons = new List<Lesson> { new Lesson("09:30","Physics","Petrova") } },
						   new DaySchedule { Day = "Wednesday", Lessons = new List<Lesson> {(new Lesson("10:30", "PE", "Shevcov")) } },
						   new DaySchedule { Day = "Thursday", Lessons = new List<Lesson> {(new Lesson("11:30", "English", "Smirnova")) } },
						   new DaySchedule { Day = "Friday", Lessons = new List<Lesson> {(new Lesson("12:00", "IT class", "Polyakov")) } }
					   }
				   },
				   new GroupSchedule
				   {
					   Group = "9Б",
					   Days = new List<DaySchedule>
					   {
							new DaySchedule { Day = "Monday", Lessons = new List<Lesson> { new Lesson("08:30","Russian","Lermotov") } },
							new DaySchedule { Day = "Tuesday", Lessons = new List<Lesson> { new Lesson("09:00","Literature","Plushkin") } },
							new DaySchedule { Day = "Wednesday", Lessons = new List<Lesson> { new Lesson("10:00","Law", "McGill") } },
							new DaySchedule { Day = "Thursday", Lessons = new List<Lesson> { new Lesson("11:30","Chemistry","White") } },
							new DaySchedule { Day = "Friday", Lessons = new List<Lesson> { new Lesson("12:00","Geography","Kolumb") } }
					   }
				   },
				   new GroupSchedule
				   {
						Group = "9В",
						Days = new List<DaySchedule>
						{
							new DaySchedule { Day = "Monday", Lessons = new List<Lesson> { new Lesson("09:00","Physics","Petrova") } },
							new DaySchedule { Day = "Tuesday", Lessons = new List<Lesson> { new Lesson("11:00","Art", "Dicaprio") } },
							new DaySchedule { Day = "Wednesday", Lessons = new List<Lesson> { new Lesson("08:00","Math","Polyakov") } },
							new DaySchedule { Day = "Thursday", Lessons = new List<Lesson> { new Lesson("10:30","Music","West") } },
							new DaySchedule { Day = "Friday", Lessons = new List<Lesson> { new Lesson("09:30","Physics","Einstien") } }
						}
				   },
					new GroupSchedule
					{
						Group = "9Г",
						Days = new List<DaySchedule>
						{
								new DaySchedule { Day = "Monday", Lessons = new List<Lesson> { new Lesson("12:00","Philosophy","Socrates") } },
								new DaySchedule { Day = "Tuesday", Lessons = new List<Lesson> { new Lesson("09:00","Chemistry","White") } },
								new DaySchedule { Day = "Wednesday", Lessons = new List<Lesson> { new Lesson("11:00","Law","McGill") } },
								new DaySchedule { Day = "Thursday", Lessons = new List<Lesson> { new Lesson("08:30","Biology","Kazarmshikova") } },
								new DaySchedule { Day = "Friday", Lessons = new List<Lesson> { new Lesson("10:00","PE","Shevcov") } }
						}
					},
				}
			};
			File.WriteAllText(_path, JsonSerializer.Serialize(sample, new JsonSerializerOptions { WriteIndented = true }));
		}
	}
	public ScheduleFile Load()
	{
		using var s = File.OpenRead(_path);
		return JsonSerializer.Deserialize<ScheduleFile>(s, _opts) ?? new ScheduleFile();
	}
}





