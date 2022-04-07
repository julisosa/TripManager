using ChallengeWirolsut.Entities;
using System.ComponentModel.DataAnnotations;

namespace ChallengeWirolsut.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public City ToEntity()
        {
            return new City
            {
                Id = Id,
                Name = Name,
            };
        }
    } 
}
