using ChallengeWirolsut.Dtos;
using ChallengeWirolsut.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeWirolsut.Entities
{
    public class Vehicle : BaseEntity
    {
        [Required]
        public VehicleType Type { get; set; }
        public string Patent { get; set; }
        public string Brand { get; set; }

        public VehicleDto ToDto()
        {
            return new VehicleDto
            {
                Id = Id,
                Type = Type.ToString(),
                Patent = Patent,
                Brand = Brand,
            };
        }
    }

}
