namespace Vfm.Data;

public class Seeds
{
    public static readonly (Country Country, string Name, int Tier, int TeamCount, int Reputation, int AvgStadiumCapacity, int AvgStadiumQuality, int AvgYouthQuality)[] Leagues =
    [
        (Country.Turkey, "Süper Lig", 1, 18, 6_300, 32_000, 72, 55),
        
        (Country.Germany, "Bundesliga", 1, 18, 8_100, 43_500, 88, 90),
        (Country.France, "Ligue 1", 1, 18, 7_500, 33_000, 75, 70),
        (Country.Italy, "Serie A", 1, 20, 8_100, 37_500, 65, 70),
        (Country.Spain, "La Liga", 1, 20, 8_400, 40_000, 82, 85),
        (Country.England, "Premier League", 1, 20, 9_000, 42_500, 90, 85),
        (Country.Brazil, "Brasileirão Série A", 1, 20, 6_500, 44_750, 62, 85),
        (Country.Argentina, "Liga Profesional", 1, 28, 6_100, 33_750, 50, 70),
        (Country.Uruguay, "Primera División", 1, 16, 4_600, 17_250, 40, 70),
        (Country.Holland, "Eredivisie", 1, 18, 6_700, 20_500, 75, 88),
        (Country.Portugal, "Primeira Liga", 1, 18, 6_900, 17_750, 72, 85),
        (Country.Belgium, "Pro League", 1, 16, 5_700, 17_000, 62, 78),
        (Country.Croatia, "HNL", 1, 10, 5_100, 15_000, 48, 75),
        (Country.Colombia, "Primera A", 1, 20, 4_900, 27_250, 50, 62),
        (Country.Mexico, "Liga MX", 1, 18, 5_500, 36_750, 62, 58),
        (Country.Nigeria, "NPFL", 1, 20, 3_600, 16_000, 30, 50),
        (Country.Senegal, "Ligue 1 Sénégal", 1, 14, 3_500, 5_500, 25, 50),
        (Country.Japan, "J1 League", 1, 20, 4_900, 32_000, 80, 65),
        (Country.Denmark, "Superliga", 1, 12, 5_000, 14_500, 70, 68),
        (Country.Morocco, "Botola Pro", 1, 16, 4_300, 33_500, 60, 52),
    ];
}