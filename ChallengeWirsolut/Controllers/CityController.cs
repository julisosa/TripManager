using ChallengeWirolsut.Dtos;
using ChallengeWirolsut.Entities;
using ChallengeWirolsut.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ChallengeWirolsut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CityPostDto cityPostDto)
        {
            if (ModelState.IsValid)
            {
                var city = cityPostDto.ToEntity();
                _unitOfWork.CityRepository.Add(city);
                _unitOfWork.SaveChanges();
                return Ok(city);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cities = _unitOfWork.CityRepository.GetAll();
            var cityDtos = new List<CityDto>();
            foreach (var city in cities)
            {
                var cityDto = city.ToDto();
                cityDtos.Add(cityDto);
            }
            return Ok(cityDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            City city = _unitOfWork.CityRepository.GetById(id);

            if (city == null)
            {
                return NotFound("Error: City not found");
            }

            return Ok(city);

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromForm] CityPostDto cityPostDto, int id)
        {

            if (ModelState.IsValid)
            {
                City cityUpdate = _unitOfWork.CityRepository.GetById(id);

                if (cityUpdate == null)
                {
                    return NotFound("Error: City not found");
                }

                cityUpdate.Name = cityPostDto.Name;

                _unitOfWork.CityRepository.Update(cityUpdate);
                _unitOfWork.SaveChanges();
                return Ok("Updated successfully");
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.CityRepository.Delete(id);
                _unitOfWork.SaveChanges();

                return Ok("Deleted successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
