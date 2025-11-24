using FirstProject.Entity;
using FirstProject.Responses;
using FirstProject.Service;
namespace FirstProject
{
    public class Program
    {


        static void Main(string[] args)
        {
            var dbContext=new EmployeeMAnegmentSystemContext();
            EmployeeService employeeService=new EmployeeService(dbContext);
            VecationRequestService vacationRequestService=new VecationRequestService(dbContext,employeeService);

            //employeeService.add_20_departments();
            //employeeService.add_20_positions();
            //employeeService.add_10_employees();
            //employeeService.updateEmployee("E001", "aliceUpdated", 1, 1, 60000);
            //employeeService.updateVacationDaysLeft("E001", 15);

            //vacationRequestService.addVacationRequest("I need a vacation", "E004", 'A',new DateOnly(2025,11,29),new DateOnly(2025,12,3),5);
            //vacationRequestService.approveVacationRequest(1,"E002");
            //vacationRequestService.declineVacationRequest(1,"E003");

            //employeeService.getAll();
            EmployeeResponse response = employeeService.GetEmployeeByEmployeeNumber("E001");
            Console.WriteLine(response);

            //vacationRequestService.getAllEmployeesPinding();
            //vacationRequestService.getAllHistoryApproved("E001");
            //vacationRequestService.getAllPindingRequests();


        }
    }
}
