using ChainOfResponsibilityDesingPattern.DAL;
using System.Collections.Generic;

namespace ChainOfResponsibilityDesingPattern.ChainOfResponsibility
{
    public abstract class Employee
    {

        protected Employee NextApprover;
        public void SetNextApprover(Employee superVisor)
        {
            this.NextApprover = superVisor;
        }
        public abstract List<string> ProcessRequest(CustomerProcessViewModel req);
    }
}
