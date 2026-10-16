using Vfm.Data;

namespace Vfm.Service;

public class Creator
{
    private static readonly Random Rng = new();

    private const int MinOffset = -2_250;
    private const int MaxOffset = 1_000;
    private const int MaxReputation = 9_500;
    private const int GuaranteeLimit = 9_000;

    public static List<League> CreateLeagues(List<Country> list)
    {
        var leagues =  new List<League>();
        foreach (var selected in list)
        {
            leagues.Add(Seeds.Leagues.Where(l => l.Country == selected).Select(l =>
                new League { Name = l.Name, Country = l.Country, Reputation = l.Reputation, Tier = l.Tier ,TeamCount = l.TeamCount, AvgStadiumCapacity = l.AvgStadiumCapacity, AvgStadiumQuality = l.AvgStadiumQuality, AvgYouthQuality = l.AvgYouthQuality}).First());
        }
        return leagues;
    }

    public static List<Team> CreateTeams(League league)
    {
        var teams = new List<Team>();
        bool guaranteeTop = league.Reputation + MaxOffset <= GuaranteeLimit;

        for (int i = 0; i < league.TeamCount; i++)
        {
            int offset = guaranteeTop && i == 0 ? MaxOffset : Rng.Next(MinOffset, MaxOffset + 1);
            int reputation = league.Reputation + offset > MaxReputation ? MaxReputation : league.Reputation + offset;
            string name = NameGenerator.TeamNameGenerate(league.Country);
            teams.Add(new Team()
            {
                Country =  league.Country,
                Name = name,
                Reputation = reputation,
                LeagueId = league.Id,
                Budget = CalculateBudget(reputation),
                StadiumName = NameGenerator.StadiumNameGenerate(league.Country, name),
                StadiumCapacity = CalculateStadiumCapacity(league, reputation),
                StadiumQuality = CalculateStadiumQuality(league, reputation),
            });
        }
        AssignYouthQuality(league, teams);
        return teams;
    }

    public static void AssignYouthQuality(League league, List<Team> teams)
    {
        var ranked = teams
            .OrderByDescending(t => 0.2 * (t.Reputation - league.Reputation - MinOffset) / (MaxOffset - MinOffset) + 0.8 * Rng.NextDouble())
            .ToList();

        for (int i = 0; i < ranked.Count; i++)
        {
            int value = i < 3 ? league.AvgYouthQuality + Rng.Next(10, 21)
                : i >= ranked.Count - 3 ? league.AvgYouthQuality - Rng.Next(25, 41)
                : league.AvgYouthQuality + Rng.Next(-8, 9);
            ranked[i].YouthCenterQuality = Math.Clamp(value, 1, 100);
        }
    }

    public static List<Player> CreatePlayers(Team team)
    {
        var positions = new List<PlayerPosition>();
        positions.AddRange(Enumerable.Repeat(PlayerPosition.Gk, 2));
        positions.AddRange(Enumerable.Repeat(PlayerPosition.Def, 8));
        positions.AddRange(Enumerable.Repeat(PlayerPosition.Mid, 8));
        positions.AddRange(Enumerable.Repeat(PlayerPosition.St, 4));

        int total = Rng.Next(22, 29);
        while (positions.Count < total)
        {
            var pool = new List<PlayerPosition> { PlayerPosition.Def, PlayerPosition.Mid, PlayerPosition.St };
            if (positions.Count(p => p == PlayerPosition.Gk) < 3)
                pool.Add(PlayerPosition.Gk);

            positions.Add(pool[Rng.Next(pool.Count)]);
        }

        return positions.Select(pos => new Player
        {
            Name = NameGenerator.PlayerNameGenerate(team.Country),
            TeamId = team.Id,
            Position = pos,
            CountryOfBirth = team.Country,
        }).ToList();
    }

    public static int CalculateStadiumCapacity(League league, int reputation)
    {
        int offset = reputation - league.Reputation;
        double baseFactor = 0.6 + 1.0 * (offset - MinOffset) / (MaxOffset - MinOffset);
        double noise = 0.85 + Rng.NextDouble() * 0.30;
        return (int)Math.Round(league.AvgStadiumCapacity * baseFactor * noise / 250) * 250;
    }

    public static int CalculateStadiumQuality(League league, int reputation)
    {
        int offset = reputation - league.Reputation;
        double shift = (offset + 625) / 1_625.0;
        int value = league.AvgStadiumQuality + (int)(shift < 0 ? shift * 35 : shift * 15) + Rng.Next(-8, 9);
        return Math.Clamp(value, 1, 100);
    }

    public static int CalculateBudget(int reputation)
    {
        double budgetFactor = 0.5 + Rng.NextDouble() * 0.8;
        int budgetK = (int)((1_000 + 346_000 / (1 + Math.Exp(-0.00099 * (reputation - 8_660)))) * budgetFactor);
        return budgetK * 1_000;
    }
}
