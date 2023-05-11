namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Paslauga;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Paslauga' entity.
/// </summary>
public class Skrydis
{
	[DisplayName("Id")]
	public int Id { get; set; }

	[DisplayName("Data")]
	[DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	[Required]
	public DateTime Data { get; set; }
}
