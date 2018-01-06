using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Don2018.PhonebookSpa.PhoneBook.People.Dto;
using Don2018.PhonebookSpa.PhoneBook.Phones.Dto;

namespace Don2018.PhonebookSpa.PhoneBook.People
{
    public interface IPersonAppService : IApplicationService
    {
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);
        Task CreatePerson(CreatePersonInput input);
        Task DeletePerson(EntityDto input);
        Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input);
        Task DeletePhone(EntityDto<long> input);
    }

}

/*An application service method gets/returns DTOs. 
 * ListResultDto is a pre-build helper DTO to return a list of another DTO.*/
