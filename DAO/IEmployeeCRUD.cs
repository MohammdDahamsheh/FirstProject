using FirstProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAO
{
    public interface IEmployeeCRUD
    {
        void add_20_departments();
        void add_20_positions();
        void add_10_employees();
        void updateEmployee(string employeeNumber, string name,int deptId,int posId,int salary);
        void updateVacationDaysLeft(string employeeNumber, int daysLeft);
    }
}
