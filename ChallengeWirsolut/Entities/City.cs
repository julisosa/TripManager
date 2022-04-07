using ChallengeWirolsut.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeWirolsut.Entities
{
    public class City : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public CityDto ToDto()
        {
            return new CityDto
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
