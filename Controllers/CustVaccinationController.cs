using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.CustVaccination;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustVaccinationController : ControllerBase
    {
        private ICustVaccinationDetailsService _custVaccinationDetailsService;
        private IMapper _mapper;

        public CustVaccinationController(
            ICustVaccinationDetailsService custVaccinationDetailsService,
            IMapper mapper)
        {
            _custVaccinationDetailsService = custVaccinationDetailsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var custVaccinationDetails = _custVaccinationDetailsService.GetAll();
            return Ok(custVaccinationDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetBySSN(int id)
        {
            var custVaccinationDetails = _custVaccinationDetailsService.GetBySSN(id);
            return Ok(custVaccinationDetails);
        }

        [HttpPost]
        public IActionResult Create(CreateVaccinationDetails model)
        {
            _custVaccinationDetailsService.Create(model);
            return Ok(new { message = "Vaccination Details created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateVaccinationDetails model)
        {
            _custVaccinationDetailsService.Update(id, model);
            return Ok(new { message = "Vaccination Details updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _custVaccinationDetailsService.Delete(id);
            return Ok(new { message = "Vaccination Details deleted" });
        }
    }
}
