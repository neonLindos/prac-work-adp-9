using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_work_adp_9.task2
{
    class Employee : OrganizationComponent
    {
        public override string Name { get; }
        public string Position { get; private set; }
        public decimal Salary { get; private set; }

        public Employee(string name, string position, decimal salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        public void SetSalary(decimal newSalary)
        {
            Salary = newSalary;
        }

        public override decimal GetBudget() => Salary;
        public override int GetStaffCount() => 1;
        public override void Display(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + $"{Name} ({Position}) - ${Salary}");
        }
    }

    class Contractor : Employee
    {
        public Contractor(string name, string position, decimal salary)
            : base(name, position, salary) { }

        public override decimal GetBudget() => 0;
    }

}
