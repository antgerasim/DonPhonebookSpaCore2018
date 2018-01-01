using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Don2018.PhonebookSpa.PhoneBook.People.Dto;

namespace Don2018.PhonebookSpa.PhoneBook.People
{
    public interface IPersonAppService : IApplicationService
    {
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);
        Task CreatePerson(CreatePersonInput input);
    }

}

/*An application service method gets/returns DTOs. 
 * ListResultDto is a pre-build helper DTO to return a list of another DTO.*/
