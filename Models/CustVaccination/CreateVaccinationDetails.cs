using System;
using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

namespace WebApi.Models.CustVaccination
{
    public class CreateVaccinationDetails
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        [MinLength(6)]
        public int SocialSecurityNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime FirstDose { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime SecondDose { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EnumDataType(typeof(VaccinationStatus))]
        public string VaccinationStatus { get; set; }

        [Required]
        [EnumDataType(typeof(VaccineName))]
        public string VaccineName { get; set; }
    }
}