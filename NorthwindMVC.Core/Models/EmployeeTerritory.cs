namespace NorthwindMVC.Core.Models
{
    public class EmployeeTerritory
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int TerritoryId { get; set; }
        public Territory Territory { get; set; }
    }
}
