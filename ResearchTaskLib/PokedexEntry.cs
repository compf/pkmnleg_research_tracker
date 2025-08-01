namespace ResearchTaskLib;

public class PokedexEntry
{
    public int Number{ get; set; }
    public string Name { get; set; }
    public string GermanName{ get; set; }
    
    public bool? EvolvesFrom{ get; set; }
    public IList<ResearchTaskEntry> ResearchTasks { get; set; }
}