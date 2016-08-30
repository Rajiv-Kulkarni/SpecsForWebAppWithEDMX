using CT3Application.Web.Data;
using Heroic.Web.IoC;
using System.Security.Principal;
using System.Web.Mvc;

namespace CT3Application.Web.Infrastructure
{
    public abstract class CT3TestApplicationWebViewPage<TModel> : WebViewPage<TModel>
    {
        public ApplicationDbContext DbContext { get; set; }
        //public CommonDbContext CommonContext { get; set; }
        public ICurrentUser CurrentUser { get; set; }
        public IIdentity _Identity { get; set; }

        protected override void InitializePage()
        {
            base.InitializePage();

            Controller controller = (this.ViewContext.Controller as Controller);
            DbContext = this.Context.GetContainer().GetInstance<ApplicationDbContext>();
            //CommonContext = this.Context.GetContainer().GetInstance<CommonDbContext>();
            CurrentUser = this.Context.GetContainer().GetInstance<ICurrentUser>();
            _Identity = this.Context.GetContainer().GetInstance<IIdentity>();
        }
    }

    public abstract class CT3TestApplicationWebViewPage : WebViewPage
    {
        public ApplicationDbContext DbContext { get; set; }
        //public CommonDbContext CommonContext { get; set; }
        public ICurrentUser CurrentUser { get; set; }
        public IIdentity _Identity { get; set; }

        protected override void InitializePage()
        {
            base.InitializePage();

            Controller controller = (this.ViewContext.Controller as Controller);
            DbContext = this.Context.GetContainer().GetInstance<ApplicationDbContext>();
            //CommonContext = this.Context.GetContainer().GetInstance<CommonDbContext>();
            CurrentUser = this.Context.GetContainer().GetInstance<ICurrentUser>();
            _Identity = this.Context.GetContainer().GetInstance<IIdentity>();
        }
    }
}