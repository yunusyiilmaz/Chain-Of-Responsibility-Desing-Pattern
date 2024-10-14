using ChainOfResponsibilityDesingPattern.DAL;
using System.Collections.Generic;

namespace ChainOfResponsibilityDesingPattern.ChainOfResponsibility
{
    public class ManagerAssistant : Employee
    {
        public override List<string> ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            List<string> messages = new List<string>();

            CustomerProcess customerProcess = new CustomerProcess
            {
                Amount = req.Amount.ToString(),
                Name = req.Name,
                EmployeeName = "Müdür Yardımcısı - Ahmet Demir"
            };

            if (req.Amount <= 150000)
            {
                customerProcess.Description = "Para çekme işlemi müdür yardımcısı tarafından onaylandı.";
                messages.Add(customerProcess.Description);
            }
            else if (NextApprover != null)
            {
                customerProcess.Description = "Para çekme tutarı müdür yardımcısının limiti aştı, işlem şube müdürüne yönlendirildi.";
                messages.Add(customerProcess.Description);

                // Zincirden gelen mesajları ekle
                messages.AddRange(NextApprover.ProcessRequest(req));
            }
            else
            {
                messages.Add("İşlem gerçekleştirilemedi.");
            }

            context.CustomerProcesses.Add(customerProcess);
            context.SaveChanges();

            return messages;
        }
    }
}
