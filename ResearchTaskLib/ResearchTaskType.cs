using System.ComponentModel;

namespace ResearchTaskLib;
public class ResearchTaskType
{
    public string Description { get; }
    public string? Argument { get; private set; }
    public ResearchTaskTypeEnum Type { get; private set; }
    public bool IsActive{get;private set;}=false;
    public ResearchTaskType(string description)
    {
        Description = description;
        ParseDescription(description);
    }
    private void ParseDescription(string description)
    {
        if (description.StartsWith("Number caught at night"))
        {
            Type = ResearchTaskTypeEnum.CaughtNight;
        }
        else if (description.StartsWith("Number caught during daylight hours"))
        {
            Type = ResearchTaskTypeEnum.CaughtDay;
        }
        else if (description.StartsWith("Number caught in the evening"))
        {
            Type = ResearchTaskTypeEnum.CaughtEvening;
        }
        else if (description.StartsWith("Number you’ve caught while they were in the air"))
        {
            Type = ResearchTaskTypeEnum.CaughtInAir;
        }
        else if (description.StartsWith("Number you’ve caught while they were sleeping"))
        {
            Type = ResearchTaskTypeEnum.CaughtSleeping;
        }
        else if (description.StartsWith("Number you’ve caught without being spotted"))
        {
            Type = ResearchTaskTypeEnum.CaughtNotSpotted;
        }
        else if (description.StartsWith("Number caught"))
        {
            Type = ResearchTaskTypeEnum.Caught;
        }
        else if(description.EndsWith("caught"))
        {
            if(description.Contains("alpha"))
            {
                Type = ResearchTaskTypeEnum.CaughtAlpha;
            }
            else if(description.Contains("heavy"))
            {
                Type = ResearchTaskTypeEnum.CaughtHeavy;
            }
            else if(description.Contains("light"))
            {
                Type = ResearchTaskTypeEnum.CaughtLight;
            }
            else if(description.Contains("small"))
            {
                Type = ResearchTaskTypeEnum.CaughtSmall;
            }
            else if(description.Contains("large"))
            {
                Type = ResearchTaskTypeEnum.CaughtLarge;
            }
            else{
                Type = ResearchTaskTypeEnum.Caught;
            }
        }
   
        else if(description.Contains("defeated with"))
        {
            string[] splitted=description.Split("-");
            splitted=splitted[0].Split(" ");
            string type=splitted[splitted.Length-1];
            Type=ResearchTaskTypeEnum.DefeatedEffective;
            Argument=type;
        }
        else if(description.Contains("strong style"))
        {
            Type=ResearchTaskTypeEnum.UsedStrongStyle;
        }
        else if(description.Contains("agile style"))
        {
            Type=ResearchTaskTypeEnum.UsedAgileStyle;
        }
        else if(description.Contains("defeated"))
        {
            Type=ResearchTaskTypeEnum.Defeated;
        }
        else if(description.Contains("scared"))
        {
            Type=ResearchTaskTypeEnum.Scared;
        }
        else if(description.Contains("stunned"))
        {
            Type=ResearchTaskTypeEnum.Stunned;
        }
        else if(description.Contains("evolved"))
        {
            Type=ResearchTaskTypeEnum.Evolved;
        }
        else if(description.Contains("seen it use"))
        {
            Type=ResearchTaskTypeEnum.UsedMove;
            string[] splitted=description.Split("use ");
            Argument=splitted[1];
            IsActive=true;
        }
        else if(description.Contains("food"))
        {
            Type=ResearchTaskTypeEnum.Food;
        }
        else if(description.Contains("leaped out of a tree"))
        {
            Type=ResearchTaskTypeEnum.LeapedOutOfTree;
        }
        else if(description.Contains("leaped out of an ore"))
        {
            Type=ResearchTaskTypeEnum.LeapedOutOfOre;
        }
        else
        {
            Type=ResearchTaskTypeEnum.Other;
        }
   
    }
    private static bool AreTasksCompatible(ResearchTaskType taskExecuted, ResearchTaskType additonalTask)
    {
        if(additonalTask.Type==ResearchTaskTypeEnum.Caught)
        {
            if(taskExecuted.Type.ToString().StartsWith(ResearchTaskTypeEnum.Caught.ToString()))
            {
                return true;
            }
        }
        else if(additonalTask.Type==ResearchTaskTypeEnum.Defeated)
        {
            if(taskExecuted.Type.ToString().StartsWith(ResearchTaskTypeEnum.Defeated.ToString()))
            {
                return true;
            }
        }
        else if(taskExecuted.Type==ResearchTaskTypeEnum.UsedMove)
        {
            string moveType=moveTypes[taskExecuted.Argument!];
            if(additonalTask.Argument==moveType)
            {
                return true;
            }
            else if(additonalTask.Type==ResearchTaskTypeEnum.UsedStrongStyle || additonalTask.Type== ResearchTaskTypeEnum.UsedAgileStyle)
            {
                return true;
            }
        }
        return false;
    }
    public bool CatchWithoutActuallyCatching(PokedexEntry entry)
    {
        if (Type == ResearchTaskTypeEnum.Caught || Type == ResearchTaskTypeEnum.CaughtHeavy ||
         Type == ResearchTaskTypeEnum.CaughtLarge ||
        Type == ResearchTaskTypeEnum.CaughtLight || Type == ResearchTaskTypeEnum.CaughtNight ||
        Type == ResearchTaskTypeEnum.CaughtDay || Type == ResearchTaskTypeEnum.CaughtEvening 
        )
        {
            return entry.EvolvesFrom ==true ;
        }
        return false;
    }
    public enum ResearchTaskTypeEnum
    {
        Caught,
        CaughtNotSpotted,
        CaughtInAir,
        CaughtSleeping,
        CaughtHeavy,
        CaughtAlpha,
        CaughtLarge,
        CaughtSmall,
        CaughtLight,
        CaughtNight,
        CaughtDay,
        CaughtEvening,
        UsedMove,
        UsedStrongStyle,
        UsedAgileStyle,
        Defeated,
        DefeatedEffective,
        Scared,
        Stunned,
        Evolved,
        Food,
        LeapedOutOfOre,
        LeapedOutOfTree,
        Other

    }
    static Dictionary<string,string> moveTypes = new Dictionary<string, string>
{
    { "Absorb", "Grass" },
    { "Acid Armor", "Poison" },
    { "Acid Spray", "Poison" },
    { "Aerial Ace", "Flying" },
    { "Air Cutter", "Flying" },
    { "Air Slash", "Flying" },
    { "Ancient Power", "Rock" },
    { "Aqua Jet", "Water" },
    { "Aqua Tail", "Water" },
    { "Astonish", "Ghost" },
    { "Aura Sphere", "Fighting" },
    { "Baby-Doll Eyes", "Fairy" },
    { "Barb Barrage", "Poison" },
    { "Bite", "Dark" },
    { "Bitter Malice", "Ghost" },
    { "Bleakwind Storm", "Flying" },
    { "Blizzard", "Ice" },
    { "Brave Bird", "Flying" },
    { "Bubble", "Water" },
    { "Bug Buzz", "Bug" },
    { "Bulk Up", "Fighting" },
    { "Bulldoze", "Ground" },
    { "Bullet Punch", "Steel" },
    { "Calm Mind", "Psychic" },
    { "Ceaseless Edge", "Dark" },
    { "Charge Beam", "Electric" },
    { "Chloroblast", "Grass" },
    { "Close Combat", "Fighting" },
    { "Confusion", "Psychic" },
    { "Cross Poison", "Poison" },
    { "Crunch", "Dark" },
    { "Dark Pulse", "Dark" },
    { "Dark Void", "Dark" },
    { "Dazzling Gleam", "Fairy" },
    { "Dire Claw", "Poison" },
    { "Double Hit", "Normal" },
    { "Double-Edge", "Normal" },
    { "Dragon Claw", "Dragon" },
    { "Dragon Pulse", "Dragon" },
    { "Draining Kiss", "Fairy" },
    { "Earth Power", "Ground" },
    { "Ember", "Fire" },
    { "Energy Ball", "Grass" },
    { "Esper Wing", "Psychic" },
    { "Extrasensory", "Psychic" },
    { "Fairy Wind", "Fairy" },
    { "Fire Blast", "Fire" },
    { "Fire Fang", "Fire" },
    { "Fire Punch", "Fire" },
    { "Flame Wheel", "Fire" },
    { "Flamethrower", "Fire" },
    { "Flare Blitz", "Fire" },
    { "Flash Cannon", "Steel" },
    { "Giga Impact", "Normal" },
    { "Gust", "Flying" },
    { "Head Smash", "Rock" },
    { "Headlong Rush", "Ground" },
    { "Hex", "Ghost" },
    { "High Horsepower", "Ground" },
    { "Hurricane", "Flying" },
    { "Hydro Pump", "Water" },
    { "Hyper Beam", "Normal" },
    { "Hypnosis", "Psychic" },
    { "Ice Beam", "Ice" },
    { "Ice Fang", "Ice" },
    { "Ice Shard", "Ice" },
    { "Icicle Crash", "Ice" },
    { "Infernal Parade", "Ghost" },
    { "Iron Defense", "Steel" },
    { "Iron Head", "Steel" },
    { "Iron Tail", "Steel" },
    { "Leaf Blade", "Grass" },
    { "Leaf Storm", "Grass" },
    { "Leafage", "Grass" },
    { "Leech Life", "Bug" },
    { "Liquidation", "Water" },
    { "Lunar Blessing", "Psychic" },
    { "Magma Storm", "Fire" },
    { "Mimic", "Normal" },
    { "Moonblast", "Fairy" },
    { "Mountain Gale", "Ice" },
    { "Mud Bomb", "Ground" },
    { "Mud-Slap", "Ground" },
    { "Mystical Fire", "Fire" },
    { "Mystical Power", "Psychic" },
    { "Nasty Plot", "Dark" },
    { "Ominous Wind", "Ghost" },
    { "Outrage", "Dragon" },
    { "Overheat", "Fire" },
    { "Petal Dance", "Grass" },
    { "Play Rough", "Fairy" },
    { "Poison Gas", "Poison" },
    { "Poison Jab", "Poison" },
    { "Poison Powder", "Poison" },
    { "Poison Sting", "Poison" },
    { "Powder Snow", "Ice" },
    { "Power Gem", "Rock" },
    { "Psychic", "Psychic" },
    { "Psycho Cut", "Psychic" },
    { "Psyshield Bash", "Psychic" },
    { "Quick Attack", "Normal" },
    { "Raging Fury", "Fire" },
    { "Recover", "Normal" },
    { "Rest", "Psychic" },
    { "Roar of Time", "Dragon" },
    { "Rock Slide", "Rock" },
    { "Rock Smash", "Fighting" },
    { "Rollout", "Rock" },
    { "Roost", "Flying" },
    { "Sandsear Storm", "Ground" },
    { "Seed Flare", "Grass" },
    { "Self-Destruct", "Normal" },
    { "Shadow Ball", "Ghost" },
    { "Shadow Claw", "Ghost" },
    { "Shadow Force", "Ghost" },
    { "Shelter", "Steel" },
    { "Silver Wind", "Bug" },
    { "Slash", "Normal" },
    { "Snarl", "Dark" },
    { "Soft-Boiled", "Normal" },
    { "Spacial Rend", "Dragon" },
    { "Spark", "Electric" },
    { "Splash", "Normal" },
    { "Spore", "Grass" },
    { "Springtide Storm", "Fairy" },
    { "Stealth Rock", "Rock" },
    { "Stone Axe", "Rock" },
    { "Struggle Bug", "Bug" },
    { "Stun Spore", "Grass" },
    { "Swords Dance", "Normal" },
    { "Tackle", "Normal" },
    { "Take Heart", "Fairy" },
    { "Teleport", "Psychic" },
    { "Thunder", "Electric" },
    { "Thunder Fang", "Electric" },
    { "Thunder Punch", "Electric" },
    { "Thunder Shock", "Electric" },
    { "Thunder Wave", "Electric" },
    { "Thunderbolt", "Electric" },
    { "Tri Attack", "Normal" },
    { "Triple Arrows", "Fighting" },
    { "Twister", "Dragon" },
    { "Venoshock", "Poison" },
    { "Victory Dance", "Fighting" },
    { "Water Pulse", "Water" },
    { "Wave Crash", "Water" },
    { "Wild Charge", "Electric" },
    { "Wildbolt Storm", "Electric" },
    { "Wood Hammer", "Grass" },
    { "X-Scissor", "Bug" },
    { "Zen Headbutt", "Psychic" }
};
}