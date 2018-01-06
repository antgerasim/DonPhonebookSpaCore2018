using System.Collections.ObjectModel;
using Abp.Application.Services.Dto;

namespace Don2018.PhonebookSpa.PhoneBook.People.Dto
{
    public class PersonListDto  : FullAuditedEntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }

        public Collection<PhoneInPersonListDto> Phones { get; set; }
    }
}