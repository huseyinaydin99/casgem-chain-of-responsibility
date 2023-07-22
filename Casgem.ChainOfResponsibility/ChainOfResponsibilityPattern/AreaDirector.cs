using Casgem.ChainOfResponsibility.DAL;

namespace Casgem.ChainOfResponsibility.ChainOfResponsibilityPattern
{
    public class AreaDirector : EmployeeBase
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 300000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Veli";
                customerProcess.Description = "Müşterinin talep ettiği tutar bölge yöneticisi tarafından öndendi";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Veli";
                customerProcess.Description = "Müşterinin talep ettiği tutar bölge yöneticisi yönlendirildi";
                context.CustomerProcess.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
