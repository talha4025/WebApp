using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.Models
{
    public class Students
    {
        // <summary>
        // Student Entity
        // <summary>

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string ContactInfo { get; set; }

        [MaxLength(20)]
        public string Department { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Column(TypeName = "float")]
        public float CGPA { get; set; }
    }
}
