using Vfm.Data;
using Vfm.Service;

namespace Vfm;

class Program
{
    static void Main(string[] args)
    {
        var leagues = Creator.CreateLeagues(
        [
            Country.Turkey,
            Country.Germany,
            Country.England,
            Country.Brazil,
            Country.Uruguay,
            Country.Senegal,
            Country.Japan,
        ]);

        string outputPath = Path.GetFullPath("output.txt");
        using var writer = new StreamWriter(outputPath);

        int teamId = 0;
        int playerId = 0;
        for (int i = 0; i < leagues.Count; i++)
        {
            var league = leagues[i];
            league.Id = i + 1;
            writer.WriteLine(Describe(league));

            foreach (var team in Creator.CreateTeams(league))
            {
                team.Id = ++teamId;
                writer.WriteLine("    " + Describe(team));

                foreach (var player in Creator.CreatePlayers(team))
                {
                    player.Id = ++playerId;
                    writer.WriteLine("        " + Describe(player));
                }
            }
            writer.WriteLine();
        }

        Console.WriteLine($"Çıktı yazıldı: {outputPath}");
    }

    static string Describe(object item) =>
        string.Join(" | ", item.GetType().GetProperties().Select(p => $"{p.Name}: {Format(p.GetValue(item))}"));

    static string? Format(object? value) => value is DateTime date ? date.ToString("yyyy-MM-dd") : value?.ToString();
}
