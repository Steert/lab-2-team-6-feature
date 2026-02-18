namespace task;

public abstract class Timeblock : IConflictChecker
{
    public int StartMin {get; set; }
    public int EndMin {get; set; }

    public Timeblock(int startMin, int endMin)
    {
        StartMin = startMin;
        EndMin = endMin;
    }

    public bool ConflictsWith(Timeblock other)
    {
        if (this.StartMin < other.EndMin && this.EndMin > other.StartMin)
        {
            return true;
        }
        return false;
    }
}