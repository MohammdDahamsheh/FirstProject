using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstProject.DAO;
using FirstProject.Entity;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Service
{
    public class VecationRequestService : IVecationRequest
    {
        public EmployeeMAnegmentSystemContext db { get; set; }
        public EmployeeService employeeService { get; set; }
        public VecationRequestService(EmployeeMAnegmentSystemContext db, EmployeeService employeeService) { this.db = db; this.employeeService = employeeService; }
        public void addVacationRequest(string description, string employeeNumber, char vacationTypeCode, DateOnly startDate, DateOnly endDate, int totalVacationDays, int requestStateId)
        {
            var vac = db.VacationRequests.Where(e => e.EmployeeNumber == employeeNumber).Include(v=>v.RequestState).FirstOrDefault();
            VacationRequest vacationRequest = new VacationRequest(DateTime.Now, description, employeeNumber, vacationTypeCode, startDate, endDate, totalVacationDays, requestStateId);

            if (vac != null&&vac.RequestState.StateName== "Submitted")
            {
               throw new Exception("There is already a submitted vacation request for this employee.....");
            }
            
            db.VacationRequests.Add(vacationRequest);
            db.SaveChanges();

        }

        public void approveVacationRequest(int requestId, string approvedByEmployeeNumber)
        {
            var request = db.VacationRequests.Where(r => r.RequestId == requestId).FirstOrDefault();
            if (request == null)
            {
                throw new Exception("Request ID not found.....");
                //Console.WriteLine("Request ID not found.....");
            }
            else
            {
                request.RequestStateId = 2; // Approve

                //request.Employee.VacationDaysLeft -= request.TotalVacationDays;
                employeeService.updateVacationDaysLeft(request.EmployeeNumber, request.TotalVacationDays);
                request.ApprovedByEmployeeNumber = approvedByEmployeeNumber;
                db.SaveChanges();
            }

        }

        public void declineVacationRequest(int requestId, string declinedByEmployeeNumber)
        {
            var request = db.VacationRequests.Where(r => r.RequestId == requestId).FirstOrDefault();
            if (request == null)
            {
                throw new Exception("Request ID not found.....");
                //Console.WriteLine("Request ID not found.....");
            }
            else
            {
                request.RequestStateId = 3; // Decline
                request.DeclinedByEmployeeNumber = declinedByEmployeeNumber;
                db.SaveChanges();

            }
        }
    }
}
