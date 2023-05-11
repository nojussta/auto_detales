namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.ContractsReport;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


/// <summary>
/// View model for single contract in a report.
/// </summary>
public class Sutartis
{
    [DisplayName("Sutartis")]
    public int Nr { get; set; }

    [DisplayName("Data")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime SutartiesData { get; set; }

    public string Vardas { get; set; }

    public string Pavarde { get; set; }

    public string AsmensKodas { get; set; }

    [DisplayName("Sudarytų sutarčių vertė")]
    public decimal Kaina { get; set; }

    [DisplayName("Užsakytų paslaugų vertė")]
    public decimal PaslauguKaina { get; set; }

    public decimal BendraSuma { get; set; }

    public decimal BendraSumaPaslaug { get; set; }

    //new code
    [DisplayName("Padalinys")]
    public string Padalinys { get; set; }

    [DisplayName("Data")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Data { get; set; }

    [DisplayName("Modelio pavadinimas")]
    public string ModelioPavadinimas { get; set; }

    [DisplayName("Dalies pavadinimas")]
    public string Dalis { get; set; }

    [DisplayName("Dalies sritis")]
    public string DaliesSritis { get; set; }

    [DisplayName("Variklio tūris")]
    public int VariklioTuris { get; set; }

    [DisplayName("Variklio galia")]
    public int Galia { get; set; }

    [DisplayName("Kuro tipas")]
    public string KuroTipas { get; set; }

    [DisplayName("Yra padaliniuose")]
    public int PadaliniuSkaicius { get; set; }
}

/// <summary>
/// View model for whole report.
/// </summary>
public class Report
{
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime? DateFrom { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime? DateTo { get; set; }

    public List<Sutartis> Sutartys { get; set; }

    public string VisoSumaSutartciu { get; set; }

    public int VisoSumaPaslaugu { get; set; }
}

public class Dalys
{
    public string Dalis { get; set; }
    public string DaliesSritis { get; set; }
    public int VariklioTuris { get; set; }
    public int Galia { get; set; }
    public string KuroTipas { get; set; }
    public int DalysSkaicius { get; set; }
}
