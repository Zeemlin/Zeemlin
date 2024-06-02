namespace Zeemlin.Service.DTOs.Users.Students;

public class StudentRankingDto
{
    public long StudentId { get; set; }
    public string StudentUniqueId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int AttendanceCount { get; set; }
    public double AverageScore { get; set; }
    public double WeightedAverage { get; set; } 
}

