using System.ComponentModel.DataAnnotations;

namespace G7.Foss.Configuration.Dto;

public class ChangeUiThemeInput
{
    [Required]
    [StringLength(32)]
    public string Theme { get; set; }
}
