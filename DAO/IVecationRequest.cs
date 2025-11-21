using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAO
{
    public interface IVecationRequest
    {
        void addVacationRequest(string description, string employeeNumber, char vacationTypeCode, DateOnly startDate, DateOnly endDate, int totalVacationDays);
        void approveVacationRequest(int requestId, string approvedByEmployeeNumber);
        void declineVacationRequest(int requestId, string declinedByEmployeeNumber);
        void getAllEmployeesPinding();
        void getAllHistoryApproved(string employeeNum);
        void getAllPindingRequests();
    }
}
