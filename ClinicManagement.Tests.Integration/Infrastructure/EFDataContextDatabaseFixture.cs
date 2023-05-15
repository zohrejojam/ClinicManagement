using ClinicManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClinicManagement.Tests.Integration.Infrastructure
{
    public class EFDataContextDatabaseFixture : IDisposable
    {
        private readonly TransactionScope _transactionScope;

        public EFDataContextDatabaseFixture()
        {
            _transactionScope = new TransactionScope(
                TransactionScopeOption.Required,
                TransactionScopeAsyncFlowOption.Enabled);
        }

      
        public EFDataContext CreateDataContext()
        {
            return new EFDataContext();
        }

        public virtual void Dispose()
        {
            _transactionScope?.Dispose();
        }
    }
}
