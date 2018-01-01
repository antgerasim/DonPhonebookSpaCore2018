using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Don2018.PhonebookSpa.Configuration;
using Don2018.PhonebookSpa.Web;

namespace Don2018.PhonebookSpa.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class PhonebookSpaDbContextFactory : IDesignTimeDbContextFactory<PhonebookSpaDbContext>
    {
        public PhonebookSpaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PhonebookSpaDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            PhonebookSpaDbContextConfigurer.Configure(builder, configuration.GetConnectionString(PhonebookSpaConsts.ConnectionStringName));

            return new PhonebookSpaDbContext(builder.Options);
        }
    }
}
