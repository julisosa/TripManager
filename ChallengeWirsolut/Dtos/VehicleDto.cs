using System.ComponentModel.DataAnnotations;

namespace ChallengeWirolsut.Dtos
{ //dataannotations
    public class VehicleDto
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [StringLength(7, MinimumLength = 6)]
        public string Patent { get; set; }
        [Required]
        public string Brand { get; set; }
    }
}
