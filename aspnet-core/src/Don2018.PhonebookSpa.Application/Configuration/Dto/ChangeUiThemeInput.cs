using System.ComponentModel.DataAnnotations;

namespace Don2018.PhonebookSpa.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [StringLength(32)]
        public string Theme { get; set; }
    }
}
