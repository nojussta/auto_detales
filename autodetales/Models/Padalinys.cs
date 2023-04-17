namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Padaliniai;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
public class Padalinys
{
    [DisplayName("ID")]
    public int Id { get; set; }

    [DisplayName("Miestas")]
    public string Miestas { get; set; }

    [DisplayName("Būsena")]
    public bool Busena { get; set; }
}
