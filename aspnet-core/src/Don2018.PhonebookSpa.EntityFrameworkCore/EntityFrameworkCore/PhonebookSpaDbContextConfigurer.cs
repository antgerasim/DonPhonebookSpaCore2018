using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Don2018.PhonebookSpa.EntityFrameworkCore
{
    public static class PhonebookSpaDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PhonebookSpaDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PhonebookSpaDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
