namespace task;

using System.Text;
using task.Collection;
using task.Comparer;

public class ScheduleManager
{
    public EventCollection schedule = new EventCollection();
    public int count { get { return schedule.count; } set; }

    public bool AddEvent(CalendarEvent newEvent)
    {
        if (newEvent == null)
        {
            return false;
        }

        schedule.Add(newEvent);

        return true;
    }

    public bool DeleteEventByIndex(int index)
    {
        if (index < 0 || index >= count)
        {
            return false;
        }
        
        schedule.RemoveAt(index);

        return true;
    }

    public string GetReport()
    {
        return $"Всього подій: {count}";
    }

    public void Sort()
    {
        Array.Sort(schedule.eventList);
    }
    
    public void DecreasingSort()
    {
        Array.Sort(schedule.eventList, new DecreasingTimeComparer());
    }

    public void AddEventFromConsole()
    {
        Console.Write("День тижня: ");
        string day = Console.ReadLine();

        Console.Write("Подія: ");
        string description = Console.ReadLine();

        Console.Write("Година початку: ");
        int startH = int.Parse(Console.ReadLine());
        Console.Write("Хвилина початку: ");
        int startM = int.Parse(Console.ReadLine());

        Console.Write("Година кінця: ");
        int endH = int.Parse(Console.ReadLine());
        Console.Write("Хвилина кінця: ");
        int endM = int.Parse(Console.ReadLine());

        int start = startH * 60 + startM;
        int end = endH * 60 + endM;

        CalendarEvent evt = new CalendarEvent(day, description, start, end);

        AddEvent(evt);

        Console.WriteLine("Подію успішно додано.");
        Console.WriteLine("----------------------");
    }

    public void DeleteEventFromConsole()
    {
        ShowEvents();
        Console.Write("Номер події для видалення: ");

        if (int.TryParse(Console.ReadLine(), out int num))
        {
            DeleteEventByIndex(num - 1);
            Console.WriteLine("Видалено.");
        }
        else
        {
            Console.WriteLine("Некоректне число.");
        }
        Console.WriteLine("----------------------");
    }

    public void ShowEvents()
    {
        if (schedule.count == 0)
        {
            Console.WriteLine("Список порожній.");
            return;
        }

        var enumerator = schedule.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }

        Console.WriteLine("----------------------");
    }

    public void ShowConflicts()
    {
        bool found = false;
        for (int i = 0; i < count; i++)
        {
            for (int j = i + 1; j < count; j++)
            {
                if (schedule[i].Day == schedule[j].Day && schedule[i].ConflictsWith(schedule[j]))
                {
                    Console.WriteLine("Знайдено конфлікт:");
                    Console.WriteLine(schedule[i]);
                    Console.WriteLine(schedule[j]);
                    found = true;
                }
            }
        }
        if (!found) Console.WriteLine("Конфліктів немає.");
        Console.WriteLine("----------------------");
    }

    public void Swap(ref CalendarEvent a, ref CalendarEvent b)
    {
        CalendarEvent temp = a;
        a = b;
        b = temp;
    }

    public static int GetDayPriority(string day)
    {
        switch (day.ToLower().Trim())
        {
            case "понеділок":
                return 1;
            case "вівторок":
                return 2;
            case "середа":
                return 3;
            case "четвер":
                return 4;
            case "п'ятниця":
                return 5;
            case "субота":
                return 6;
            case "неділя":
                return 7;
            default:
                return 8;
        }
    }
}