using AutoMapper;
using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.CustVaccination;

namespace WebApi.Services
{
    public interface ICustVaccinationDetailsService
    {
        IEnumerable<VaccinationDetail> GetAll();
        VaccinationDetail GetBySSN(int socialSecurityNum);
        void Create(CreateVaccinationDetails model);
        void Update(int socialSecurityNum, UpdateVaccinationDetails model);
        void Delete(int socialSecurityNum);
    }

    public class CustVaccinationDetailsService : ICustVaccinationDetailsService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public CustVaccinationDetailsService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<VaccinationDetail> GetAll()
        {
            
            return _context.CustVaccinationDetails;
        }

        public VaccinationDetail GetBySSN(int id)
        {
            return getCustVaccinationDetail(id);
        }

        public void Create(CreateVaccinationDetails model)
        {
            
            // map model to new user object
            var custVaccination = _mapper.Map<VaccinationDetail>(model);
            // save user
            _context.CustVaccinationDetails.Add(custVaccination);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateVaccinationDetails model)
        {
            var custVaccination = getCustVaccinationDetail(id);
            // copy model to user and save
            _mapper.Map(model, custVaccination);
            _context.CustVaccinationDetails.Update(custVaccination);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var custVaccination = getCustVaccinationDetail(id);
            _context.CustVaccinationDetails.Remove(custVaccination);
            _context.SaveChanges();
        }

        // helper methods

        private VaccinationDetail getCustVaccinationDetail(int id)
        {
            var custVaccination = _context.CustVaccinationDetails.Find(id);
            if (custVaccination == null) throw new KeyNotFoundException("Vaccination Details not found");
            return custVaccination;
        }
    }
}
