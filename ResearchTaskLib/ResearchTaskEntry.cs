namespace ResearchTaskLib;

public class ResearchTaskEntry
{
    public ResearchTaskType Type{get;set;}
    public int AmountDone{get;set;}
    public int Points{get;set;}

    public ResearchGoal[] Goals{get;set;}
}