using ChallengeWirolsut.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeWirolsut.Dtos
{
    public class TicketPostDto
    {
        [Required]
        public int CityId { get; set; }
        [Required]
        public DateTime Depart { get; set; }
        [Required]
        public int VehicleId { get; set; }

        public Ticket ToEntity()
        {
            return new Ticket
            {
                CityId = CityId,
                Depart = Depart,
                VehicleId = VehicleId,
            };
        }
    }
}
