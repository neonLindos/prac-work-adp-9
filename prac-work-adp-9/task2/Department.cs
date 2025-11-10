using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_work_adp_9.task2
{
    class Department : OrganizationComponent
    {
        private List<OrganizationComponent> _children = new List<OrganizationComponent>();
        public override string Name { get; }

        public Department(string name)
        {
            Name = name;
        }

        public void Add(OrganizationComponent component)
        {
            _children.Add(component);
        }

        public void Remove(OrganizationComponent component)
        {
            _children.Remove(component);
        }

        public override decimal GetBudget()
        {
            return _children.Sum(c => c.GetBudget());
        }

        public override int GetStaffCount()
        {
            return _children.Sum(c => c.GetStaffCount());
        }

        public override void Display(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + $"Department: {Name}");
            foreach (var child in _children)
            {
                child.Display(indent + 4);
            }
        }

        public Employee FindEmployee(string name)
        {
            foreach (var child in _children)
            {
                if (child is Employee emp && emp.Name == name)
                    return emp;
                if (child is Department dept)
                {
                    var result = dept.FindEmployee(name);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        public List<Employee> ListAllEmployees()
        {
            var all = new List<Employee>();
            foreach (var child in _children)
            {
                if (child is Employee emp)
                    all.Add(emp);
                else if (child is Department dept)
                    all.AddRange(dept.ListAllEmployees());
            }
            return all;
        }
    }
}
