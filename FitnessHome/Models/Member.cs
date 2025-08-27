using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FitnessHome.Models
{
    public class Member
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [MaxLength(100)]
        [Column("first_name")]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        [Column("last_name")]
        public string? LastName { get; set; }

        [MaxLength(100)]
        [Column("email")]
        public string? Email { get; set; }
    }
}
