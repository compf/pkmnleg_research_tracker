namespace ResearchTaskLib
{
    public struct ResearchGoal
    {
        public int Achieved { get; set; }

        public bool HasAchieved(int goal)
        {
            return Achieved <= goal;
        }
        public ResearchGoal(int achieved)
        {
            Achieved = achieved;
        }
    }

}