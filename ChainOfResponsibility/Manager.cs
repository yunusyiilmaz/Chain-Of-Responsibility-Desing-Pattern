using ChainOfResponsibilityDesingPattern.DAL;
using System.Collections.Generic;

namespace ChainOfResponsibilityDesingPattern.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override List<string> ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            List<string> messages = new List<string>();
            CustomerProcess customerProcess = new CustomerProcess
            {
                Amount = req.Amount.ToString(),
                Name = req.Name,
                EmployeeName = "Şube Müdürü - Ömer Adalet"
            };
            if (req.Amount <= 250000)
            {
                customerProcess.Description = "Para çekme işlemi onaylandı,müşteri talep ettiği tutar ödendi.";
                messages.Add(customerProcess.Description);
            }
            else if (NextApprover != null)
            {
                customerProcess.Description = "Para çekme tutarı Şube Müdürünün günlük ödeyebileceği limiti aştığı için işlem bölge müdürüne yönlendirildi.";
                messages.Add(customerProcess.Description);

                messages.AddRange(NextApprover.ProcessRequest(req));
                //NextApprover.ProcessRequest(req);
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
