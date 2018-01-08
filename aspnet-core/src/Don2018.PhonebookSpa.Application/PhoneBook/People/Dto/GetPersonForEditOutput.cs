using Abp.AutoMapper;

namespace Don2018.PhonebookSpa.PhoneBook.People.Dto
{
    [AutoMapTo(typeof(Person))]
    public class GetPersonForEditOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
    }
}