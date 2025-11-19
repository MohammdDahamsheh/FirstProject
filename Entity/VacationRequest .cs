using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Entity
{
    public class VacationRequest
    {
        [Key]
        public int RequestId { get; set; }
        [Required]
        public DateTime RequestSubmissionDate { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public int EmployeeNumber { get; set; }

        public char VacationTypeCode { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        public int TotalVacationDays { get; set; }

        [Required]
        public int RequestStateId { get; set; }

        public string ?ApprovedByEmployeeNumber { get; set; }
        public string ?DeclinedByEmployeeNumber{ get; set; }

        public VacationRequest(DateTime requestSubmissionDate, string description, int employeeNumber, char vacationTypeCode, DateOnly startDate, DateOnly endDate, int totalVacationDays, int requestStateId)
        {
            RequestSubmissionDate = requestSubmissionDate;
            Description = description;
            EmployeeNumber = employeeNumber;
            VacationTypeCode = vacationTypeCode;
            StartDate = startDate;
            EndDate = endDate;
            TotalVacationDays = totalVacationDays;
            RequestStateId = requestStateId;
        }
    }
}
