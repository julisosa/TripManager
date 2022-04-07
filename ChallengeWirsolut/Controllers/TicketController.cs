using ChallengeWirolsut.Dtos;
using ChallengeWirolsut.Entities;
using ChallengeWirolsut.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeWirolsut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TicketPostDto ticketPostDto)
        {
            if (ModelState.IsValid)
            {
                var vehicle = _unitOfWork.VehicleRepository.GetById(ticketPostDto.VehicleId);

                if (vehicle == null)
                {
                    return NotFound("Error: Vehicle not found");
                }

                var city = _unitOfWork.CityRepository.GetById(ticketPostDto.CityId);

                if (city == null)
                {
                    return NotFound("Error: City not found");
                }

                var ticket = ticketPostDto.ToEntity();
                _unitOfWork.TicketRepository.Add(ticket);
                _unitOfWork.SaveChanges();
                return Ok(ticket);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tickets = await _unitOfWork.TicketRepository.Query().Include("Vehicle").Include("City").ToListAsync();
            var ticketDtos = new List<TicketDto>();
            foreach (var ticket in tickets)
            {
                var ticketDto = ticket.ToDto();
                ticketDtos.Add(ticketDto);
            }
            return Ok(ticketDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Ticket ticket = await _unitOfWork.TicketRepository.Query().Include("Vehicle").Include("City").FirstOrDefaultAsync(x => id == x.Id);
            
            if (ticket == null)
            {   
                return NotFound();
            }
            var ticketDto = ticket.ToDto();

            return Ok(ticketDto);

        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] TicketPostDto ticketPostDto, int id)
        {
            if (ModelState.IsValid)
            {
                Ticket ticketUpdate = _unitOfWork.TicketRepository.GetById(id);

                if (ticketUpdate == null)
                {
                    return NotFound("Error: City not found");
                }

                ticketUpdate.VehicleId = ticketPostDto.VehicleId;
                ticketUpdate.Depart = ticketPostDto.Depart;
                ticketUpdate.CityId = ticketPostDto.CityId;

                _unitOfWork.TicketRepository.Update(ticketUpdate);
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
                _unitOfWork.TicketRepository.Delete(id);
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
