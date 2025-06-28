namespace ResearchTaskLib;

public class ResearchTaskEntry
{
    public int AmountDone { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public ResearchTaskType Type => new ResearchTaskType(Description);

    public int[] Goals { get; set; }
}