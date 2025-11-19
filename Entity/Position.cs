using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Entity
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }
        [Required]
        [MaxLength(50)]
        public string PositionName { get; set; }
        public Position(string positionName)
        {
            PositionName = positionName;
        }
       
    }
}
