using Casgem.ChainOfResponsibility.DAL;

namespace Casgem.ChainOfResponsibility.ChainOfResponsibilityPattern
{
    public class Treassurer : EmployeeBase
    {

        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 5000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Hüseyin";
                customerProcess.Description = "Müşterinin talep ettiği tutar veznedar tarafından öndendi";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Hüseyin";
                customerProcess.Description = "Müşteri taraından talep edilen tutar,günlük ödeme bakiyemi aştığı için sizi şube müdür yardımcısına yönlendiriyorum";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
