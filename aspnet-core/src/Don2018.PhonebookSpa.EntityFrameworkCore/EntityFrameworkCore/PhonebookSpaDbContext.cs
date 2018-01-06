using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Don2018.PhonebookSpa.Authorization.Roles;
using Don2018.PhonebookSpa.Authorization.Users;
using Don2018.PhonebookSpa.MultiTenancy;
using Don2018.PhonebookSpa.PhoneBook.People;
using Don2018.PhonebookSpa.PhoneBook.Phones;

namespace Don2018.PhonebookSpa.EntityFrameworkCore
{
    public class PhonebookSpaDbContext : AbpZeroDbContext<Tenant, Role, User, PhonebookSpaDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }

        public PhonebookSpaDbContext(DbContextOptions<PhonebookSpaDbContext> options)
            : base(options)
        {
        }
    }
}
