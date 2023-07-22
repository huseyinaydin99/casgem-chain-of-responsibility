using Casgem.ChainOfResponsibility.DAL;

namespace Casgem.ChainOfResponsibility.ChainOfResponsibilityPattern
{
    public class ManagerAssistant : EmployeeBase
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 50000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Mahmut";
                customerProcess.Description = "Müşterinin talep ettiği tutar şube müdür yardımcısı tarafından öndendi";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Mahmut";
                customerProcess.Description = "Müşterinin talep ettiği tutar şube müdürüne yönlendirildi";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
