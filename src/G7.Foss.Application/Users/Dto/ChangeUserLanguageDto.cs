using System.ComponentModel.DataAnnotations;

namespace G7.Foss.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}