namespace ResearchTaskLib;

public class PokedexEntry
{
    public int Number{ get; set; }
    public string Name { get; set; }
    public IList<ResearchTaskEntry> ResearchTasks{get;set;}
}