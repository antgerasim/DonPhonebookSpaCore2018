using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Castle.Core.Internal;
using Don2018.PhonebookSpa.PhoneBook.People.Dto;

namespace Don2018.PhonebookSpa.PhoneBook.People
{
    public class PersonAppService : PhonebookSpaAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personAppService)
        {
            _personRepository = personAppService;
        }

        public ListResultDto<PersonListDto> GetPeople(GetPeopleInput input)
        {
            var persons = _personRepository.GetAll().WhereIf(!input.Filter.IsNullOrEmpty(),
                p => p.Name.Contains(input.Filter) || p.Surname.Contains(input.Filter) ||
                     p.EmailAddress.Contains(input.Filter)).OrderBy(p => p.Name).ThenBy(p => p.Surname).ToList();

            var retVal = new ListResultDto<PersonListDto>(ObjectMapper.Map<List<PersonListDto>>(persons));

            return retVal;
        }

        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Person>(input);
            await _personRepository.InsertAsync(person);
        }
    }
}