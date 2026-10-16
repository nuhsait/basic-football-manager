namespace Vfm.Data;

public record CountryInfo(string Name, string Nationality);

public static class Countries
{
    private static readonly Dictionary<Country, CountryInfo> Infos = new()
    {
        [Country.Turkey] = new("Türkiye", "Türk"),
        [Country.Germany] = new("Almanya", "Alman"),
        [Country.France] = new("Fransa", "Fransız"),
        [Country.Italy] = new("İtalya", "İtalyan"),
        [Country.Spain] = new("İspanya", "İspanyol"),
        [Country.England] = new("İngiltere", "İngiliz"),
        [Country.Brazil] = new("Brezilya", "Brezilyalı"),
        [Country.Argentina] = new("Arjantin", "Arjantinli"),
        [Country.Uruguay] = new("Uruguay", "Uruguaylı"),
        [Country.Holland] = new("Hollanda", "Hollandalı"),
        [Country.Portugal] = new("Portekiz", "Portekizli"),
        [Country.Belgium] = new("Belçika", "Belçikalı"),
        [Country.Croatia] = new("Hırvatistan", "Hırvat"),
        [Country.Colombia] = new("Kolombiya", "Kolombiyalı"),
        [Country.Mexico] = new("Meksika", "Meksikalı"),
        [Country.Nigeria] = new("Nijerya", "Nijeryalı"),
        [Country.Senegal] = new("Senegal", "Senegalli"),
        [Country.Japan] = new("Japonya", "Japon"),
        [Country.Denmark] = new("Danimarka", "Danimarkalı"),
        [Country.Morocco] = new("Fas", "Faslı"),
    };

    public static CountryInfo Get(Country country) => Infos[country];
}