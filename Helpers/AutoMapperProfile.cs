using AutoMapper;
using WebApi.Entities;
using WebApi.Models.CustVaccination;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateRequest -> User
            CreateMap<CreateVaccinationDetails, VaccinationDetail>();

            // UpdateRequest -> User
            CreateMap<UpdateVaccinationDetails, VaccinationDetail>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore both null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "VaccinationStatus" && src.VaccinationStatus == null) return false;

                        if (x.DestinationMember.Name == "VaccineName" && src.VaccineName == null) return false;

                        return true;
                    }
                ));
        }
    }
}