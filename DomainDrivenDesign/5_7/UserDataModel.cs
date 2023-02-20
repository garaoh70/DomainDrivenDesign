using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainDrivenDesign.List5_7;

[Table("users")]
public record class UserDataModel
{
    [Key]
    [Required]
    public string UserId { get; set; } = "";

    [Required]
    public string UserName { get; set; } = "";
}