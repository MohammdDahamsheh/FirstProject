using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Entity
{
    public class VacationType
    {
        [Key]
        public char VacationTypeCode { get; set; }
        [MaxLength(20)]
        public string VacationTypeName { get; set; }
    }
}
