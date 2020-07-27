using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookAPI.Dtos;
using BookAPI.Entity;
using BookAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controller
{

    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetCountries")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200,Type = typeof(IEnumerable<CountryDto>))]
        public IActionResult GetCountries()
        {
            var countries = unitOfWork.Countries.GetAll().OrderBy(country => country.Name);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countriesDto = mapper.Map<IEnumerable<CountryDto>>(countries);


            return Ok(countriesDto);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountry(int countryId)
        {
             var country = unitOfWork.Countries.GetById(countryId);

            if (country == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryDto = mapper.Map<CountryDto>(country);


            return Ok(countryDto);
        }

        [HttpGet("author/{authorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountryByAuthorId(int authorId)
        {
            var country = unitOfWork.Countries.GetCountryByAuthorId(authorId);

            if (country == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryDto = mapper.Map<CountryDto>(country);


            return Ok(countryDto);
        }

        [HttpPost("")]
        [ProducesResponseType(400)]
        public IActionResult AddCountry([FromBody]Country country)
        {
            if (country == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            
            unitOfWork.Countries.Add(country);
            int result = unitOfWork.Save();

            return CreatedAtRoute("GetCountries", country);
        }


        [HttpPut("")]
        [ProducesResponseType(400)]
        public IActionResult UpdateCountry([FromBody]Country country)
        {
            if (country == null || !ModelState.IsValid)
                return BadRequest(ModelState);


            unitOfWork.Countries.Update(country);

            int result = unitOfWork.Save();

            return CreatedAtRoute("GetCountries", country);
        }

    }
}