namespace task;

interface IConflictChecker
{
    bool ConflictsWith(Timeblock other);
}