using ChallengeWirolsut.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeWirolsut.Dtos
{
    public class CityPostDto
    {
        [Required]
        public string Name { get; set; }

        public City ToEntity()
        {
            return new City
            {
                Name = Name,
            };
        }
    }
}
