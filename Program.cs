using FirstProject.Entity;
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
            //vacationRequestService.addVacationRequest("I need a vacation","E001",'B',new DateOnly(2025,11,29),new DateOnly(2025,12,3),5,1);
            //vacationRequestService.approveVacationRequest(1,"E002");

            vacationRequestService.declineVacationRequest(1,"E003");


        }
    }
}
