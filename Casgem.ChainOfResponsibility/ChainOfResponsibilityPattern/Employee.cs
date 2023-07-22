namespace Casgem.ChainOfResponsibility.ChainOfResponsibilityPattern
{
    public abstract class EmployeeBase
    {
        protected EmployeeBase NextApprover;//Approver : Onaylayıcı demek, burası miras alan alt classlar için nesne örneği veriyor
        public void SetNextApprover(EmployeeBase Superviseor)
        {
            this.NextApprover = Superviseor;
        }
        public abstract void ProcessRequest(CustomerProcessViewModel request);
    }
}
