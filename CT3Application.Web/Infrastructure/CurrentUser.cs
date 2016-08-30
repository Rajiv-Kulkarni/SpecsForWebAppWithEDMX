using CT3Application.Web.Data;
using CT3Application.Web.Identity;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.Web;

namespace CT3Application.Web.Infrastructure
{
    public class CurrentUser : ICurrentUser
    {
        private readonly ApplicationDbContext _context;
        //private readonly CommonDbContext _commonContext;
        private readonly IIdentity _identity;
        private ApplicationUser _user;

        public CurrentUser(IIdentity identity, ApplicationDbContext context)
        {
            _identity = identity;
            _context = context;
            //_commonContext = commonContext;
            UpdateUserWithRoles();
        }


        public ApplicationUser User => new ApplicationUser() { DisplayName = "Rajiv Kulkarni", Id = "myId", Role = "Administrator", UserDomain = "myDomain" };

        public void AnotherDummyMethod()
        {

        }


        private void UpdateUserWithRoles()
        {
            //retrieve the user 
            //if (_context.tbl_user_profile.Any())
            //{
            //    List<tbl_user_profile> userProfileRows = _context.tbl_user_profile.Where(u => u.PersonnelID.Contains(Id)).ToList();

            //    var roles = new List<string>();//new user
            //    roles.Add("Guest");
            //    if (userProfileRows.Any())
            //    {
            //        foreach (tbl_user_profile userProfileRow in userProfileRows)
            //        {
            //            //retrieve the user roles from the database
            //            roles.Add(_context.tbl_roletypes.Where(r => r.ID == userProfileRow.tbl_RoleTypes_ID.Value).FirstOrDefault().RoleName);
            //        }
            //    }

            //    //create a GenericPrincipal 
            //    var genPrincipal = new GenericPrincipal(_identity, roles.ToArray());

            //    Thread.CurrentPrincipal = genPrincipal;
            //    HttpContext.Current.User = genPrincipal;//this will enable use of Authorize attribute with roles
            //}
        }

        private string Id
        {
            get
            {
                string id = string.Empty;
                //UserPrincipal u = UserPrincipal.Current;
                using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
                {
                    if (_identity.Name != string.Empty)
                    {
                        using (UserPrincipal user = UserPrincipal.FindByIdentity(ctx, _identity.Name))
                        {
                            if (user != null)
                            {
                                //id = user.Name;
                                //id = _identity.Name.Split('\\').GetValue(1).ToString();
                                id = user.EmployeeId;
                            }
                        }
                    }
                }

                HttpContext.Current.Items["ApplicationUserId"] = id;
                return id;
            }
        }
    }
}