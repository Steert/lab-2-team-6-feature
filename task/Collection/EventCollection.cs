namespace task.Collection;

using System.Collections;

public class EventCollection : IEnumerable
{
    public CalendarEvent[] eventList = [];
    public int count = 0;

    public CalendarEvent this[int index] { get { return eventList[index]; } }

    public void Add(object obj)
    {
        if (obj is not CalendarEvent newTask) { throw new InvalidCastException(); }

        CalendarEvent[] result = new CalendarEvent[count + 1];
        for (int i = 0; i < count; i++)
        {
            result[i] = eventList[i];
        }

        result[count++] = newTask;
        eventList = result;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count) { throw new IndexOutOfRangeException(); }

        CalendarEvent[] result = new CalendarEvent[count - 1];
        for (int i = 0, j = 0; i < count; i++, j++)
        {
            if (i == index) { j--; continue; }
            result[j] = eventList[i];
        }

        count--;
        eventList = result;
    }

    public CalendarEvent GetAt(int index)
    {
        if (index < 0 || index >= count) { throw new IndexOutOfRangeException(); }

        return eventList[index];
    }

    public void SetAt(int index, object obj)
    {
        if (index < 0 || index >= count) { throw new IndexOutOfRangeException(); }
        if (obj is not CalendarEvent newEvent) { throw new InvalidCastException(); }

        eventList[index] = newEvent;
    }

    public IEnumerator GetEnumerator()
    {
        return new EventEnumerator(eventList);
    }
}