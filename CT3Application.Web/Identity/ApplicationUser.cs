using AutoMapper;
using Heroic.AutoMapper;
using Microsoft.Ajax.Utilities;

namespace CT3Application.Web.Identity
{
    public class ApplicationUser : IHaveCustomMappings, IApplicationUser
    {
        public virtual string Id { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Role { get; set; }
        public virtual string UserDomain { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            try
            {
                //configuration.CreateMap<vw_employees, ApplicationUser>()
                //    .ForMember(m => m.Id, opt =>
                //        opt.MapFrom(u => u.ID))
                //    .ForMember(m => m.DisplayName, opt =>
                //        opt.MapFrom(u => u.Name));
            }
            catch (AutoMapperConfigurationException ex)
            {
                throw;
            }
        }

        public virtual int DummyMethod(string test)
        {
            //Console.WriteLine("overridden method");
            if (!test.IsNullOrWhiteSpace())
            {
                return test.Length;
            }
            else
            {
                return 0;
            }
        }
    }
}