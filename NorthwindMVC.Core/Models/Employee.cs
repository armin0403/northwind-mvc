﻿namespace NorthwindMVC.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[]? Photo { get; set; } = null;
        public string Notes { get; set; }
        public int? ReportsToId { get; set; }
        public Employee? ReportsTo { get; set; }
        public string PhotoPath { get; set; }

        public ICollection<EmployeeTerritory> EmployeeTerritories { get; set;}
    }
}
