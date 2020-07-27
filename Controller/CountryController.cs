using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookAPI.Dtos;
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

        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = unitOfWork.Countries.GetAll().OrderBy(country => country.Name).ToList();
            var countriesDto = mapper.Map<List<CountryDto>>(countries);


            return Ok(countriesDto);
        }

    }
}