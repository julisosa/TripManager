using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeWirolsut.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime LastModified { get; set; }
        public bool SoftDelete { get; set; }
    }
}
