namespace NorthwindMVC.Core.Models
{
    public class Territory
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
       
        public ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
