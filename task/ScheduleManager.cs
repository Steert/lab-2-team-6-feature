namespace task;
using System.Text;

public class ScheduleManager
{
    public CalendarEvent[] schedule = new CalendarEvent[200]; 
    public int count = 0;
    
    
    public bool AddEvent(CalendarEvent newEvent)
    {
        if (newEvent == null)
        {
            return false;
        }
        
        if (count >= schedule.Length)
        {
            throw new Exception("Список подій переповнений!");
        }
        
        schedule[count] = newEvent;
        count++;
        return true;
    }
    
    public bool DeleteEventByIndex(int index)
    {
        if (index < 0 || index >= count)
        {
            return false;
        }
        
        for (int i = index; i < count - 1; i++)
        {
            schedule[i] = schedule[i + 1];
        }
        
        schedule[count - 1] = null;
        count--;
        return true;
    }
    
    public string GetReport()
    {
        return $"Всього подій: {count}";
    }
    
    public void Sort()
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                int p1 = GetDayPriority(schedule[j].Day);
                int p2 = GetDayPriority(schedule[j + 1].Day);
                
                if (p1 > p2)
                {
                    Swap(ref schedule[j], ref schedule[j + 1]);
                }
                
                else if (p1 == p2 && schedule[j].StartMin > schedule[j + 1].StartMin)
                {
                    Swap(ref schedule[j], ref schedule[j + 1]);
                }
            }
        }
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
        if (count == 0)
        {
            Console.WriteLine("Список порожній.");
            return;
        }
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{i + 1}. {schedule[i]}");
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
    
    public int GetDayPriority(string day)
    {
        switch (day.ToLower().Trim()) { 
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