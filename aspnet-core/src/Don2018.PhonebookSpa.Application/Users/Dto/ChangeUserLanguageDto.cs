using System.ComponentModel.DataAnnotations;

namespace Don2018.PhonebookSpa.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}