using System.Collections;

namespace task.Comparer;

public class DecreasingTimeComparer : IComparer
{
    public int Compare(object? obj1, object? obj2)
    {
        CalendarEvent event1 = (CalendarEvent)obj1;
        CalendarEvent event2 = (CalendarEvent)obj2;

        return event2.CompareTo(event1);
    }
}