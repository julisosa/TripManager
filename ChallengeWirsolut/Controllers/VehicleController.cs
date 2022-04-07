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
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post([FromBody] VehiclePostDto vehiclePostDto)
        {
            if (ModelState.IsValid)
            {
                var vehicle = vehiclePostDto.ToEntity();
                _unitOfWork.VehicleRepository.Add(vehicle);
                _unitOfWork.SaveChanges();
                return Ok(vehicle);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet]
        public IActionResult Get()
        {
            var vehicles = _unitOfWork.VehicleRepository.GetAll();
            var vehicleDtos = new List<VehicleDto>();
            foreach (var vehicle in vehicles)
            {
                var vehicleDto = vehicle.ToDto();
                vehicleDtos.Add(vehicleDto);
            }
            return Ok(vehicleDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Vehicle vehicle = _unitOfWork.VehicleRepository.GetById(id);

            if (vehicle == null)
            {
                return NotFound("Error: Vehicle not found");
            }

            var vehicleDto = vehicle.ToDto();

            return Ok(vehicleDto);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromForm] VehiclePostDto vehiclePostDto, int id)
        {

            if (ModelState.IsValid)
            {
                Vehicle vehicleUpdate = _unitOfWork.VehicleRepository.GetById(id);

                if (vehicleUpdate == null)
                {
                    return NotFound("Error: Vehicle not found");
                }

                vehicleUpdate.Type = vehiclePostDto.Type;
                vehicleUpdate.Patent = vehiclePostDto.Patent;
                vehicleUpdate.Brand = vehiclePostDto.Brand;

                _unitOfWork.VehicleRepository.Update(vehicleUpdate);
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
                _unitOfWork.VehicleRepository.Delete(id);
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
