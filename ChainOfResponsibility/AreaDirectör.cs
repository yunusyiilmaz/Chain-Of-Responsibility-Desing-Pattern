using ChainOfResponsibilityDesingPattern.DAL;
using System.Collections.Generic;

namespace ChainOfResponsibilityDesingPattern.ChainOfResponsibility
{
    public class AreaDirectör : Employee
    {
        public override List<string> ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            List<string> messages = new List<string>();
            CustomerProcess customerProcess = new CustomerProcess
            {
                Amount = req.Amount.ToString(),
                Name = req.Name,
                EmployeeName = "Bölge Direktörü - Ebubekir Sadık"
            };
            if (req.Amount <= 400000)
            {
                customerProcess.Description = "Para çekme işlemi onaylandı,müşteri talep ettiği tutar ödendi.";
                messages.Add(customerProcess.Description);
            }
            else if (NextApprover != null)
            {
                customerProcess.Description = "Para çekme tutarı Bölge Direktörünün günlük ödeyebileceği limiti aştığı için işlem gerçekleştirilemedi " +
                "müşterinin günlük maximum çekebileceği maximum tutar 400.000 tl olup daha fazlası için birden fazla şubeye gelmesi gerekli..";
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
