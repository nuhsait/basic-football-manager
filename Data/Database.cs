using Vfm.Service;
using SQLite;

namespace Vfm.Data;

public class Database
{
    private static string DbPath
    {
        get
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "vfm");
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, "manager.db");
        }
    }
    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(DbPath);
    }

    public static void Initialize(IEnumerable<Country> selectedCountries)
    {
        using var db = GetConnection();
		
        db.CreateTable<League>();
        db.CreateTable<Team>();
        db.CreateTable<Player>();

        var leagues = Creator.CreateLeagues(selectedCountries.ToList());

        db.RunInTransaction(() =>
        {
            foreach (var league in leagues)
            {
                db.Insert(league);
                var teams = Creator.CreateTeams(league);
                db.InsertAll(teams, runInTransaction: false);
                foreach (var team in teams)
                    db.InsertAll(Creator.CreatePlayers(team), runInTransaction: false);
            }
        });

        // db.CreateTable<Staff>();
		
		
        Console.WriteLine($"Veritabanı ve tüm tablolar başarıyla oluşturuldu: {DbPath}");
    }
}