using ChallengeWirolsut.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeWirolsut.Dtos
{
    public class TicketDto
    {
        public int Id { get; set; }
        //[Required]
        //public int CityId { get; set; }
        [Required]
        public DateTime Depart { get; set; }
        //[Required]
        //public int VehicleId { get; set; }
        public CityDto City { get; set; }
        public VehicleDto Vehicle { get; set; }

        public Ticket ToEntity()
        {
            return new Ticket
            {
                Id = Id,
                //CityId = CityId,
                Depart = Depart,
                //VehicleId = VehicleId,
            };
        }
    }
}
