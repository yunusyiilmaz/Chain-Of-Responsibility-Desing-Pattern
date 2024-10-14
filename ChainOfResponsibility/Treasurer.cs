using ChainOfResponsibilityDesingPattern.DAL;
using System.Collections.Generic;

namespace ChainOfResponsibilityDesingPattern.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override List<string> ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            List<string> messages = new List<string>();

            CustomerProcess customerProcess = new CustomerProcess
            {
                Amount = req.Amount.ToString(),
                Name = req.Name,
                EmployeeName = "Veznedar - Ali Yılmaz"
            };

            if (req.Amount <= 100000)
            {
                customerProcess.Description = "Para çekme işlemi onaylandı, müşteri talep ettiği tutar ödendi.";
                messages.Add(customerProcess.Description);
            }
            else if (NextApprover != null)
            {
                customerProcess.Description = "Para çekme tutarı veznedarın limiti aştığı için işlem müdür yardımcısına yönlendirildi.";
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
