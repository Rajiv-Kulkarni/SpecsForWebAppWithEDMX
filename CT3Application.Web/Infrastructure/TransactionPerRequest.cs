using CT3Application.Web.Data;
using CT3Application.Web.Infrastructure.Tasks;
using System.Data;
using System.Data.Entity;
using System.Web;

namespace CT3Application.Web.Infrastructure
{
    public class TransactionPerRequest :
        IRunOnEachRequest, IRunOnError, IRunAfterEachRequest
    {
        private readonly ApplicationDbContext _dbContext;
        //private readonly CommonDbContext _commonContext;
        private readonly HttpContextBase _httpContext;

        public TransactionPerRequest(ApplicationDbContext dbContext,
            HttpContextBase httpContext)
        {
            _dbContext = dbContext;
            _httpContext = httpContext;
        }

        void IRunOnEachRequest.Execute()
        {
            _httpContext.Items["_Transaction"] =
                _dbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        void IRunOnError.Execute()
        {
            _httpContext.Items["_Error"] = true;
        }

        void IRunAfterEachRequest.Execute()
        {
            var transaction = (DbContextTransaction)_httpContext.Items["_Transaction"];

            if (_httpContext.Items["_Error"] != null)
            {
                transaction.Rollback();
            }
            else
            {
                if (transaction != null)
                {
                    transaction.Commit();
                }
            }
        }
    }
}