using System.Text.Json;

namespace ResearchTaskLib;
static class ExxtensionMethods
{
    public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TValue> createFunc)
    {
        if (!dict.TryGetValue(key, out TValue val))
        {
            val = createFunc();
            dict.Add(key, val);
        }

        return val;
    }

}
public static class ResearchData{
    public static List<PokedexEntry> Pokedex=new List<PokedexEntry>();
    static ResearchData()
    {
        Pokedex = JsonSerializer.Deserialize<List<PokedexEntry>>(File.ReadAllText("research_output.json"));
    }

}
