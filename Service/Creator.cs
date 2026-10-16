using Vfm.Data;

namespace Vfm.Service;

public class Creator
{
    private static readonly Random Rng = new();

    private const int MinOffset = -2_250;
    private const int MaxOffset = 1_000;
    private const int MaxReputation = 9_500;
    private const int GuaranteeLimit = 9_000;

    private const int MaxRate = 10_000;
    private const int SoftCap = 8_500;
    private const int MinAge = 18;
    private const int MaxAge = 34;
    private const double StarterBonus = 1.10;

    private static readonly double[] AgeFactors =
        [0.62, 0.70, 0.78, 0.85, 0.90, 0.95, 1, 1, 1, 1, 1, 1, 0.98, 0.95, 0.92, 0.88, 0.84];

    private static readonly double[] AgeRooms =
        [1.0, 1.0, 0.8, 0.6, 0.45, 0.3, 0.1, 0.1, 0.1, 0.1, 0.1, 0, 0, 0, 0, 0, 0];

    private static readonly Dictionary<PlayerPosition, int> Formation = new()
    {
        [PlayerPosition.Gk] = 1,
        [PlayerPosition.Def] = 4,
        [PlayerPosition.Mid] = 4,
        [PlayerPosition.St] = 2,
    };

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

        var noises = positions.Select(_ => 0.75 + 0.25 * (Rng.NextDouble() + Rng.NextDouble())).ToList();
        double noiseMean = noises.Average();
        double teamBase = 0.80 * team.Reputation + 200;

        var players = positions.Select((pos, i) =>
        {
            int age = GenerateAge(team.YouthCenterQuality);
            double current = Math.Min(teamBase * AgeFactors[age - MinAge] * AcademyFactor(age, team.YouthCenterQuality) * noises[i] / noiseMean, MaxRate);
            return new Player
            {
                Name = NameGenerator.PlayerNameGenerate(team.Country),
                TeamId = team.Id,
                Position = pos,
                CountryOfBirth = team.Country,
                BirthDate = DateTime.Today.AddYears(-age).AddDays(-Rng.Next(365)),
                CurrentRate = (int)Math.Round(current),
                PotentialRate = (int)Math.Round(CalculatePotential(current, age, team.YouthCenterQuality)),
            };
        }).ToList();

        ApplyStarterBonus(players);
        return players;
    }

    public static int GenerateAge(int youthQuality)
    {
        double youngShare = 0.10 + 0.25 * youthQuality / 100.0;
        double veteranShare = 0.18 + 0.20 * Math.Max(0, (50 - youthQuality) / 50.0);
        double roll = Rng.NextDouble();

        if (roll < youngShare)
            return Rng.Next(18, 21);
        if (roll < youngShare + veteranShare)
            return Rng.Next(29, MaxAge + 1);
        return 21 + (int)((Rng.NextDouble() + Rng.NextDouble()) / 2 * 8);
    }

    public static double AcademyFactor(int age, int youthQuality) =>
        age <= 21 ? 1 + (youthQuality - 50) / 500.0 : 1;

    public static double CalculatePotential(double current, int age, int youthQuality)
    {
        double room = (MaxRate - current) * AgeRooms[age - MinAge];
        bool rare = Rng.NextDouble() < 0.003 + 0.012 * youthQuality / 100.0;
        double u = rare
            ? 0.6 + Rng.NextDouble() * 0.4
            : 0.6 * Math.Pow(Rng.NextDouble(), 4 - 2.5 * youthQuality / 100.0);
        return current + u * room;
    }

    public static void ApplyStarterBonus(List<Player> players)
    {
        var starters = Formation
            .SelectMany(f => players.Where(p => p.Position == f.Key).OrderByDescending(p => p.CurrentRate).Take(f.Value))
            .ToHashSet();

        double total = players.Sum(p => (double)p.CurrentRate);
        double starterTotal = starters.Sum(p => (double)p.CurrentRate);
        double benchFactor = (total - StarterBonus * starterTotal) / (total - starterTotal);

        foreach (var player in players)
        {
            double factor = starters.Contains(player) ? StarterBonus : benchFactor;
            player.CurrentRate = ClampRate(player.CurrentRate * factor);
            player.PotentialRate = ClampRate(player.PotentialRate * factor);
        }
    }

    private static int ClampRate(double value)
    {
        if (value > SoftCap)
            value = SoftCap + (MaxRate - SoftCap) * (1 - Math.Exp(-(value - SoftCap) / (MaxRate - SoftCap)));
        return (int)Math.Clamp(Math.Round(value), 0, MaxRate);
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
