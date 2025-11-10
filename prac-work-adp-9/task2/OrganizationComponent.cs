using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_work_adp_9.task2
{
    abstract class OrganizationComponent
    {
        public abstract string Name { get; }
        public abstract decimal GetBudget();
        public abstract int GetStaffCount();
        public abstract void Display(int indent = 0);
    }

}
