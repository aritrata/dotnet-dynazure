using System;
using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

namespace WebApi.Models.CustVaccination
{
    public class UpdateVaccinationDetails
    {
        public int CustomerId { get; set; }

        private string _socialSecurityNumber;
        [MinLength(6)]
        public string SocialSecurityNumber
        {
            get => _socialSecurityNumber;
            set => _socialSecurityNumber = replaceEmptyWithNull(value);
        }
        [DataType(DataType.Date)]
        public DateTime FirstDose { get; set; } 
        [DataType(DataType.Date)]
        public DateTime SecondDose { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [EnumDataType(typeof(VaccinationStatus))]
        public string VaccinationStatus { get; set; }

        [EnumDataType(typeof(VaccineName))]
        public string VaccineName { get; set; }

        // helpers

        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}