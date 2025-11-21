using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstProject.DAO;
using FirstProject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FirstProject.Service
{

    public class VecationRequestService : IVecationRequest
    {
        public EmployeeMAnegmentSystemContext db { get; set; }
        public EmployeeService employeeService { get; set; }
        public VecationRequestService(EmployeeMAnegmentSystemContext db, EmployeeService employeeService) { this.db = db; this.employeeService = employeeService; }
        public void addVacationRequest(string description, string employeeNumber, char vacationTypeCode, DateOnly startDate, DateOnly endDate, int totalVacationDays)
        {
            var vac = db.VacationRequests.Where(e => e.EmployeeNumber == employeeNumber).FirstOrDefault();
            VacationRequest vacationRequest = new VacationRequest(DateTime.Now, description, employeeNumber, vacationTypeCode, startDate, endDate, totalVacationDays, 1);

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

        public void getAllEmployeesPinding()
        {
            var vacations = (from v in db.VacationRequests
                             join e in db.Employees
                             on v.EmployeeNumber equals e.EmployeeNumber
                             where v.RequestStateId == 1
                             select new
                             {
                                 e.EmployeeNumber,
                                 e.EmployeeName,
                                 e.department.DepartmentName,
                                 e.position.PositionName
                             }
                             ).Distinct();
            foreach (var vac in vacations)
            {
                Console.WriteLine(
                    $"Employee Number: {vac.EmployeeNumber}" +
                    $", Employee Name: {vac.EmployeeName}" +
                    $", Department Name: {vac.DepartmentName}" +
                    $", Position Name: {vac.PositionName}"
                    );

            }
        }

        public void getAllHistoryApproved(string employeeNum)
        {
            var vacations = db.VacationRequests.Include(v => v.VacationType).Where(v => v.RequestStateId == 2 && v.EmployeeNumber == employeeNum).ToList();
            if (vacations.IsNullOrEmpty()) Console.WriteLine("No vacathins request is found ....");
            else
                foreach (var vac in vacations)
                {
                    Console.WriteLine(
                        $", Vacation Type: {vac.VacationType.VacationTypeName}" +
                        $", Description: {vac.Description}" +
                        $", Start Date: {vac.StartDate}" +
                        $", End Date: {vac.EndDate}" +
                        $", Total Vacation Days: {vac.TotalVacationDays}" +
                        $", Approved by: {vac.ApprovedByEmployeeNumber}"
                        );
                }
            Console.WriteLine("-----------------------------------------------------");
        }

        public void getAllPindingRequests()
        {
            var vacations = (from vac in db.VacationRequests
                             join emp in db.Employees
                             on vac.EmployeeNumber equals emp.EmployeeNumber
                             where vac.RequestStateId == 1
                             select new
                             {
                                 vac.Description,
                                 vac.EmployeeNumber,
                                 emp.EmployeeName,
                                 vac.RequestSubmissionDate,
                                 vac.TotalVacationDays,
                                 vac.StartDate,
                                 vac.EndDate,
                                 emp.Salary
                             }


                             );
            if (vacations.IsNullOrEmpty()) Console.WriteLine("NO pinding requests is found .....");
            else
            {
                foreach (var vac in vacations)
                {
                    Console.WriteLine(
                        $"Description: {vac.Description}" +
                        $"Employee Number:{vac.EmployeeNumber}" +
                        $", Employee Name: {vac.EmployeeName}" +
                        $", Request Submission Date: {vac.RequestSubmissionDate}" +
                        $", Total Vacation Days: {vac.TotalVacationDays}" +
                        $", Start Date: {vac.StartDate}" +
                        $", End Date: {vac.EndDate}" +
                        $", Salary: {vac.Salary}\n"
                        );
                    Console.WriteLine("-----------------------------------------------------");
                }



            }

        }
    }
}
