using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  public class RecipeModels
  {
    public int ID { get; set; }
    [Display(Name = "Nazwa przepisu")]
    public string NazwaPrzepis { get; set; }
    public string Autor { get; set; }
    public string Kategoria { get; set; }
    [Display(Name = "Składniki")]
    public string Skladniki { get; set; }
    public string Wykonanie { get; set; }
    [Display(Name = "Data dodania")]
    [DisplayFormat(DataFormatString = "{0:d}")]
    public DateTime? DataDodania { get; set; }
    [Display(Name = "Data modyfikacji")]
    public DateTime? DataModyfikacji { get; set; }
  }
}