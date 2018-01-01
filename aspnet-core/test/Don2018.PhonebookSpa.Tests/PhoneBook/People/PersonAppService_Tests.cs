using System.Linq;
using System.Threading.Tasks;
using Abp.Runtime.Validation;
using Don2018.PhonebookSpa.PhoneBook.People;
using Don2018.PhonebookSpa.PhoneBook.People.Dto;
using Shouldly;
using Xunit;

namespace Don2018.PhonebookSpa.Tests.PhoneBook.People
{
    public class PersonAppService_Tests : PhonebookSpaTestBase
    {
        public PersonAppService_Tests()
        {
            _personAppService = Resolve<IPersonAppService>();
        }

        private readonly IPersonAppService _personAppService;

        [Fact]
        public async Task Should_Create_Person_With_Valid_Arguments()
        {
            //Act 
            await _personAppService.CreatePerson(
                new CreatePersonInput
                {
                    Name = "Frank",
                    Surname = "Sinatra",
                    EmailAddress = "frankieboy@britneyspears.su"
                });

            //Assert 
            UsingDbContext(context =>
            {
                var frank = context.Persons.FirstOrDefault(p => p.EmailAddress == "frankieboy@britneyspears.su");
                frank.ShouldNotBe(null);
                frank.Name.ShouldBe("Frank");
            });
        }

        [Fact]
        public void Should_Get_People_With_Filter()
        {
            //BUG Test doesnt work without putting AppContext.SetSwitch in PreInitialize() in CoreModule.cs!!
            //Act
            var persons = _personAppService.GetPeople(
                new GetPeopleInput
                {
                    Filter = "adams"
                });

            //Assert
            persons.Items.Count.ShouldBe(1);
            persons.Items[0].Name.ShouldBe("Douglas");
            persons.Items[0].Surname.ShouldBe("Adams");
        }

        [Fact]
        public async Task Should_Not_Create_Person_With_Invalid_Arguments()
        {
            //Act and Assert
            await Assert.ThrowsAsync<AbpValidationException>(
                async () =>
                {
                    await _personAppService.CreatePerson(
                        new CreatePersonInput
                        {
                            Name = "Frank"
                        });
                });
        }
    }
}