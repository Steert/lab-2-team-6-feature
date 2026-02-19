using System.Collections;

namespace task.Collection;

public class EventEnumerator : IEnumerator
{
    private CalendarEvent[] eventList;
    private int position = -1;
    public object Current { get { return eventList[position]; } }

    public EventEnumerator(CalendarEvent[] eventList)
    {
        this.eventList = eventList;
    }

    public bool MoveNext()
    {
        position++;
        return position < eventList.Length;
    }

    public void Reset()
    {
        position = -1;
    }
}
