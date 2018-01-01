using System.Linq;
using Don2018.PhonebookSpa.PhoneBook;

namespace Don2018.PhonebookSpa.EntityFrameworkCore.Seed.Host
{
    public class InitialPeopleCreator
    {
        private readonly PhonebookSpaDbContext _context;

        public InitialPeopleCreator(PhonebookSpaDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            //todo check proper import for FirstOrDefault (linq or ?)
            var douglas = _context.Persons.FirstOrDefault(p => p.EmailAddress == "douglas.adams@fortytwo.com");
            if (douglas == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Douglas",
                        Surname = "Adams",
                        EmailAddress = "douglas.adams@fortytwo.com"
                    });
            }

            var asimov = _context.Persons.FirstOrDefault(p => p.EmailAddress == "isaac.asimov@foundation.org");
            if (asimov == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Isaac",
                        Surname = "Asimov",
                        EmailAddress = "isaac.asimov@foundation.org"
                    });
            }

            var paris = _context.Persons.FirstOrDefault(p => p.EmailAddress == "paris@hilton.com");
            if (paris ==null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Paris",
                        Surname = "Hilton",
                        EmailAddress = "paris@hilton.com"
                    });
            }
        }
    }
}