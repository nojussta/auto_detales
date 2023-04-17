namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.ModelioSpecifikacijos;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
public class ModelioSpecifikacijos
{
    [DisplayName("ID")]
    public int ID { get; set; }

    [DisplayName("Pavadinimas")]
    [Required]
    public string Pavadinimas { get; set; }


    [DisplayName("Variklio turis")]
    [Required]
    public int VariklioTuris { get; set; }

    [DisplayName("Galia")]
    [Required]
    public int Galia { get; set; }

    [DisplayName("Kuro tipas")]
    [Required]
    public int KuroTipas { get; set; }

    [DisplayName("Modelis")]
    [Required]
    public int FkModelis { get; set; }
}

