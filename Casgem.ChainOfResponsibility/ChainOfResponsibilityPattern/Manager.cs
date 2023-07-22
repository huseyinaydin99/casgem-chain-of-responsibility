using Casgem.ChainOfResponsibility.DAL;

namespace Casgem.ChainOfResponsibility.ChainOfResponsibilityPattern
{
    public class Manager : EmployeeBase
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Ayhan";
                customerProcess.Description = "Müşterinin talep ettiği tutar müdür  tarafından öndendi";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Ayhan";
                customerProcess.Description = "Müşterinin talep ettiği tutar ödenemedi bölge yöneticisine yönlendirildi.";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
