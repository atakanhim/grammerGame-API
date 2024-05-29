namespace grammerGame.Domain.Enums
{
    public enum Rank
    {
        Beginner,
        Intermediate,
        Advanced,
        Expert
    }
    namespace grammerGame.Domain.Enums
    {
        public enum Rank
        {
            Beginner = 0,
            Intermediate = 1,
            Advanced = 2,
            Expert = 3
        }

        public static class RankMap
        {
            private static readonly Dictionary<Rank, string> _rankToNameMap = new Dictionary<Rank, string>()
            {
              { Rank.Beginner, "Beginner" },
              { Rank.Intermediate, "Intermediate" },
              { Rank.Advanced, "Advanced" },
              { Rank.Expert, "Expert" }
            };

            public static string GetName(Rank rank)
            {
                if (_rankToNameMap.ContainsKey(rank))
                {
                    return _rankToNameMap[rank];
                }
                else
                {
                    throw new ArgumentException($"Invalid Rank value: {rank}");
                }
            }
        }
    }

}
