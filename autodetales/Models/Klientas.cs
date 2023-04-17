namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Klientas' entity.
/// </summary>
public class Klientas
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("Vardas")]
    [Required]
    public string Vardas { get; set; }

    [DisplayName("Pavardė")]
    [Required]
    public string Pavarde { get; set; }

    [DisplayName("Gimimo data")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    [Required]
    public DateTime? GimimoData { get; set; }

    [DisplayName("Elektroninis paštas")]
    [EmailAddress]
    [Required]
    public string Epastas { get; set; }
}
