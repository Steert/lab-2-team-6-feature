namespace task;

public class CalendarEvent : Timeblock
{
    public string Day {get; set; }
    public string Description {get; set; }

    public CalendarEvent(string day, string description, int startMin, int endMin) : base(startMin, endMin)
    {
        Day = day;
        Description = description;
    }

    public override string ToString()
    {
        int startHour = StartMin / 60;
        int startMinute = StartMin % 60;
        
        int endHour = EndMin / 60;
        int endMinute = EndMin % 60;

        return $"{Day}: {Description} ({startHour:D2}:{startMinute:D2} - {endHour:D2}:{endMinute:D2})";
    }
}