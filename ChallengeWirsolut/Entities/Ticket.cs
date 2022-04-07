using ChallengeWirolsut.Dtos;
using System;

namespace ChallengeWirolsut.Entities
{
    public class Ticket : BaseEntity
    {
        public int CityId { get; set; }
        public City City { get; set; }
        public DateTime Depart { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public TicketDto ToDto()
        {

            CityDto cityDto = new CityDto
            {
                Id = City.Id,
                Name = City.Name
            };

            VehicleDto vehicleDto = new VehicleDto
            {
                Id = Vehicle.Id,
                Brand = Vehicle.Brand,
                Patent = Vehicle.Patent,
                Type = Vehicle.Type.ToString()
            };

            return new TicketDto
            {
                Id = Id,
                City = cityDto,
                Depart = Depart,
                Vehicle = vehicleDto,
            };
        }
    }
}
