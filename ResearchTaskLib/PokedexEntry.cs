namespace ResearchTaskLib;

public class PokedexEntry
{
    public string PokemonName{get;set;}
    public IList<ResearchTaskEntry> ResearchTasks{get;set;}
}