using SpecsFor.Configuration;
using System.Transactions;

namespace IntegrationSpecs.TestHelpers
{
    public class TransactionScopeWrapper : Behavior<INeedDatabase>
    {
        private TransactionScope _scope;

        public override void SpecInit(INeedDatabase instance)
        {
            _scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        }

        public override void AfterSpec(INeedDatabase instance)
        {
            _scope.Dispose();
        }
    }
}
