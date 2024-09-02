using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedEase_Campus_Clinic.Startup))]
namespace MedEase_Campus_Clinic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
