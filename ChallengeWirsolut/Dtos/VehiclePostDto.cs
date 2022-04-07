using ChallengeWirolsut.Entities;
using ChallengeWirolsut.Enums;
using System.ComponentModel.DataAnnotations;

namespace ChallengeWirolsut.Dtos
{
    public class VehiclePostDto
    {
        [Required]
        public VehicleType Type { get; set; }
        [Required]
        [StringLength(7, MinimumLength = 6)]
        public string Patent { get; set; }
        [Required]
        public string Brand { get; set; }

        public Vehicle ToEntity()
        {
            return new Vehicle
            {
                Type = Type,
                Patent = Patent,
                Brand = Brand,
            };
        }
    }
}
