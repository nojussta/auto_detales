﻿namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.Modelis;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Modelis' entity.
/// </summary>
public class ModelisN
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("Pavadinimas")]
    public string Pavadinimas { get; set; }

    //Markė
    [DisplayName("Markė")]
    public int FkMarke { get; set; }

    //Additional fields
    [DisplayName("Serija")]
    public string Serija { get; set; }

    [DisplayName("Gaminimo data")]
    public DateTime GaminimoData { get; set; }

    [DisplayName("Kebulo tipas")]
    public int FkKebuloTipas { get; set; }
}


/// <summary>
/// Model of 'Modelis' entity used in lists.
/// </summary>
public class ModelisLN
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("Pavadinimas")]
    public string Pavadinimas { get; set; }

    [DisplayName("Markė")]
    public string Marke { get; set; }

    //Additional fields
    [DisplayName("Serija")]
    public string Serija { get; set; }

    [DisplayName("Gaminimo data")]
    public DateTime GaminimoData { get; set; }

    [DisplayName("Kebulo tipas")]
    public int FkKebuloTipas { get; set; }
}


/// <summary>
/// Model of 'Modelis' entity used in creation and editing forms.
/// </summary>
public class ModelisCEN
{
    /// <summary>
    /// Entity data
    /// </summary>
    public class ModelM
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Pavadinimas")]
        [MaxLength(20)]
        [Required]
        public string Pavadinimas { get; set; }

        [DisplayName("Markė")]
        [Required]
        public int FkMarke { get; set; }

        //Additional fields
        [DisplayName("Serija")]
        [MaxLength(20)]
        [Required]
        public string Serija { get; set; }

        [DisplayName("Gaminimo data")]
        [Required]
        public DateTime GaminimoData { get; set; }

        [DisplayName("Kebulo tipas")]
        [Required]
        public int FkKebuloTipas { get; set; }
    }

    /// <summary>
    /// Select lists for making drop downs for choosing values of entity fields.
    /// </summary>
    public class ListsM
    {
        public IList<SelectListItem> Markes { get; set; }
    }

    /// <summary>
    /// Entity view.
    /// </summary>
    public ModelM Model { get; set; } = new ModelM();

    /// <summary>
    /// Lists for drop down controls.
    /// </summary>
    public ListsM Lists { get; set; } = new ListsM();
}

