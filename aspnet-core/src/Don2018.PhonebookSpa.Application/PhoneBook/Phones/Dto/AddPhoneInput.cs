using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Don2018.PhonebookSpa.PhoneBook.People;

namespace Don2018.PhonebookSpa.PhoneBook.Phones.Dto
{
    [AutoMapTo(typeof(Phone))]
    public class AddPhoneInput
    {
        [Range(1, int.MaxValue)]
        public int PersonId { get; set; }
        [Required]
        public PhoneType Type { get; set; }
        [Required]
        [MaxLength(PhoneConsts.MaxNumberLength)]
        public string Number { get; set; }
    }
}