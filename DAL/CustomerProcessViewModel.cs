using System.Collections.Generic;

namespace ChainOfResponsibilityDesingPattern.DAL
{
    public class CustomerProcessViewModel
    {
        public int CustomerProcessId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmployeeName { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
