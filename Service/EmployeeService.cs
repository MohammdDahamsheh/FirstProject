using FirstProject.DAO;
using FirstProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Service
{
    public class EmployeeService : IEmployeeCRUD
    {
        public EmployeeMAnegmentSystemContext db { get; set; }
        public EmployeeService(EmployeeMAnegmentSystemContext db) { 
           this.db = db;

        }
        public void add_10_employees()
        {
            var employees = new List<Employee>
            {
                new Employee("E001", "Alice", 1, 1, 'F', null, 5000),
                new Employee("E002", "Bob", 2, 2, 'M', "E001", 4500),
                new Employee("E003", "Charlie", 1, 3, 'M', "E001", 4700),
                new Employee("E004", "Diana", 3, 2, 'F', "E002", 4800),
                new Employee("E005", "Ethan", 2, 1, 'M', "E002", 4600)
            };
            db.Employees.AddRange(employees);
            db.SaveChanges();
        }

        public void add_20_departments()
        {
            string[] departments = new string[20]
            {
                "Human Resources",
                "Finance",
                "Marketing",
                "Sales",
                "IT",
                "Operations",
                "Customer Service",
                "Research and Development",
                "Legal",
                "Procurement",
                "Administration",
                "Production",
                "Quality Assurance",
                "Logistics",
                "Public Relations",
                "Business Development",
                "Training",
                "Compliance",
                "Health and Safety",
                "Engineering"
            };

            foreach (var dept in departments)
            {
                Department department = new Department(dept);
                db.Departments.Add(department);
            }
            db.SaveChanges();

        }

        public void add_20_positions()
        {
            string[] positions = new string[20]
            {
                "Manager",
                "Team Leader",
                "Software Engineer",
                "Senior Developer",
                "Junior Developer",
                "HR Specialist",
                "Marketing Manager",
                "Sales Executive",
                "Accountant",
                "Project Coordinator",
                "Business Analyst",
                "Product Owner",
                "UI/UX Designer",
                "Database Administrator",
                "IT Support",
                "Quality Assurance",
                "Network Engineer",
                "Operations Manager",
                "Customer Service Rep",
                "Consultant"
            };

            foreach (var pos in positions)
            {
                Position position = new Position(pos);
                db.Add<Position>(position);

            }
            db.SaveChanges();

        }

        public void updateEmployee(string employeeNumber, string name, int deptId, int posId, int salary)
        {
            var employee = db.Employees.Where(e => e.EmployeeNumber == employeeNumber).FirstOrDefault();
            if (employee != null)
            {
                employee.EmployeeName = name;
                employee.DepartmentId = deptId;
                employee.PositionId = posId;
                employee.Salary = salary;
                db.SaveChanges();
            }
        }

        public void updateVacationDaysLeft(string employeeNumber, int daysLeft)
        {
            var employee = db.Employees.Where(e => e.EmployeeNumber == employeeNumber).FirstOrDefault();
            if (employee == null) { throw new Exception("The employee is not found "); }
            if (employee.VacationDaysLeft < daysLeft)
            {
                throw new Exception("The days of the vecation you need is grater than the day you have ");
            }
            else
            {

                employee.VacationDaysLeft -= daysLeft;
                db.SaveChanges();
            }

        }
    }
}
