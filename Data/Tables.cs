using SQLite;

namespace Vfm.Data;

[Table("Teams")]
public class Team
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int LeagueId { get; set; }
    public int Budget { get; set; }
    public int Reputation { get; set; }
    public string StadiumName { get; set; }
    public int StadiumQuality { get; set; }
    public int StadiumCapacity { get; set; }
    public int TicketPrice { get; set; }
    public int YouthCenterQuality { get; set; }
    public Country Country { get; set; }
}

[Table("Players")]
public class Player
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int TeamId { get; set; }
    public DateTime BirthDate { get; set; }
    public PlayerPosition Position { get; set; }
    public int CurrentRate { get; set; }
    public int PotentialRate { get; set; }
    public int GrowthRate { get; set; }
    public int Reputation { get; set; }
    public int Energy { get; set; }
    public int Morale { get; set; }
    public Country CountryOfBirth { get; set; }
    public int Wage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ReleaseClause { get; set; }
}

[Table("Leagues")]
public class League
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public Country Country  { get; set; }
    public int Tier { get; set; }
    public int Reputation { get; set; }
    public int TeamCount { get; set; }
    public int AvgStadiumCapacity { get; set; }
    public int AvgStadiumQuality { get; set; }
    public int AvgYouthQuality { get; set; }
}

// [Table("Staffs")]
// public class Staff
// {
//     [PrimaryKey,AutoIncrement]
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public string Role { get; set; }
//     public int Rate { get; set; }
// }
//
// [Table("StaffContracts")]
// public class StaffContract
// {
//     [PrimaryKey,AutoIncrement]
//     
// }