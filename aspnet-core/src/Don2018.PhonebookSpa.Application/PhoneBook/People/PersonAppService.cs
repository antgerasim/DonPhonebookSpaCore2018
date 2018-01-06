using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Castle.Core.Internal;
using Don2018.PhonebookSpa.Authorization;
using Don2018.PhonebookSpa.PhoneBook.People.Dto;
using Don2018.PhonebookSpa.PhoneBook.Phones;
using Don2018.PhonebookSpa.PhoneBook.Phones.Dto;
using Microsoft.EntityFrameworkCore;

namespace Don2018.PhonebookSpa.PhoneBook.People
{
    [AbpAuthorize(PermissionNames.Pages_Tenant_PhoneBook)]
    public class PersonAppService : PhonebookSpaAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Phone, long> _phoneRep;

        public PersonAppService(IRepository<Person> personRep, IRepository<Phone, long> phoneRep)
        {
            _personRepository = personRep;
            _phoneRep = phoneRep;
        }

        public ListResultDto<PersonListDto> GetPeople(GetPeopleInput input)
        {
            var persons = _personRepository
                .GetAll()
                .Include(p => p
                    .Phones) //without Include would also work, but but slower since it will lazy load phone numbers for every person seperately
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) ||
                         p.Surname.Contains(input.Filter) ||
                         p.EmailAddress.Contains(input.Filter)
                )
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Surname)
                .ToList();

            var retVal = new ListResultDto<PersonListDto>(ObjectMapper.Map<List<PersonListDto>>(persons));

            return retVal;
        }

        [AbpAuthorize(PermissionNames.Pages_Tenant_PhoneBook_CreatePerson)]
        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Person>(input);
            await _personRepository.InsertAsync(person);
        }

        [AbpAuthorize(PermissionNames.Pages_Tenant_PhoneBook_DeletePerson)]
        public async Task DeletePerson(EntityDto input)
        {
            var person = await _personRepository.GetAsync(input.Id);
            await _personRepository.DeleteAsync(person);
        }

        /*Instead of creating a seperated IPhoneAppService, we considering Person as an aggregate and add phone related methods */
        //todo add later phonePermissions as childs for EditPerson (editPhone etc)
        [AbpAuthorize(PermissionNames.Pages_Tenant_PhoneBook_EditPerson)]
        public async Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input)
        {
            var person = _personRepository.Get(input.PersonId);
            await _personRepository.EnsureCollectionLoadedAsync(person, p => p.Phones);

            var phone = ObjectMapper.Map<Phone>(input);
            person.Phones.Add(phone);
            //Get auto increment Id of the new Phone by saving to database
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<PhoneInPersonListDto>(phone);
        }

        [AbpAuthorize(PermissionNames.Pages_Tenant_PhoneBook_EditPerson)]
        public async Task DeletePhone(EntityDto<long> input)
        {
            await _phoneRep.DeleteAsync(input.Id);
        }
    }
}