using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Entity
{
    public class RequestState
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        [MaxLength(10)]
        public string StateName { get; set; }

        public RequestState(string stateName)
        {
            StateName = stateName;
        }
    }
}
