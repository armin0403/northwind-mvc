﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace NorthwindMVC.Web.ViewModels;

    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
        public DateTime HireDate { get; set; } = DateTime.UtcNow;
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public IFormFile PhotoUpload { get; set; }
        public string PhotoPath { get; set; }
        public string Notes { get; set; }
        public int? ReportsToId { get; set; }
        public EmployeeViewModel? ReportsTo { get; set; }
        public IEnumerable<SelectListItem> EmployeeDropdown { get; set; }
    }

