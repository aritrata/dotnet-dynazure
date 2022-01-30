using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
public class VaccinationDetail
    {
        public int Id { get; set; }
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [Display(Name = "Social Security Number")]
        public int SocialSecurityNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "First Dose")]
        public DateTime FirstDose { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Second Dose")]
        public DateTime SecondDose { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Vaccination Status")]
        public VaccinationStatus VaccinationStatus { get; set; }

        [Display(Name = "Vaccine Name")]
        public VaccineName VaccineName { get; set; }

        
    }
}