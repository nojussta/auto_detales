namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.DalysF2;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// 'Sutartis' in list form.
/// </summary>
public class DalysL
{
    [DisplayName("ID")]
    public int ID { get; set; }

    [DisplayName("Dalis")]
    public string Dalis { get; set; }

    [DisplayName("Dalies sritis")]
    public string DaliesSritis { get; set; }

    [DisplayName("Modelio specifikacija")]
    public string FkSpec { get; set; }
}

/// <summary>
/// 'Sutartis' in create and edit forms.
/// </summary>
public class DalysCE
{
    /// <summary>
    /// Entity data.
    /// </summary>
    public class DalysM
    {
        //new
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("Dalis")]
        [Required]
        public string Dalis { get; set; }


        [DisplayName("Dalies sritis")]
        [Required]
        public string DaliesSritis { get; set; }

        [DisplayName("Modelio specifikacija")]
        [Required]
        public string FkSpec { get; set; }
    }

    /// <summary>
    /// Representation of 'UzsakytaPaslauga' entity in 'Sutartis' edit form.
    /// </summary>
    public class PadalinysM
    {
        public int InListId { get; set; }
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime Data { get; set; }

        [DisplayName("Padalinys")]
        [Required]
        public string Padalinys { get; set; }
    }

    /// <summary>
    /// Select lists for making drop downs for choosing values of entity fields.
    /// </summary>
    public class ListsM
    {
        public IList<SelectListItem> ModelioSpecifikacijos { get; set; }
        public IList<SelectListItem> Padaliniai { get; set; }
    }

    /// <summary>
    /// Sutartis.
    /// </summary>
    public DalysM Dalis { get; set; } = new DalysM();

    /// <summary>
    /// Related 'UzsakytaPaslauga' records.
    /// </summary>
    public IList<PadalinysM> PasirinktiPadaliniai { get; set; } = new List<PadalinysM>();

    /// <summary>
    /// Lists for drop down controls.
    /// </summary>
    public ListsM Lists { get; set; } = new ListsM();
}