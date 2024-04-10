using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPLabb1.Models;

public enum Months
{
    [Display(Name = "January")]
    January = 1,
    [Display(Name = "February")]
    February,
    [Display(Name = "March")]
    March,
    [Display(Name = "April")]
    April,
    [Display(Name = "May")]
    May,
    [Display(Name = "June")]
    June,
    [Display(Name = "July")]
    July,
    [Display(Name = "August")]
    August,
    [Display(Name = "September")]
    September,
    [Display(Name = "October")]
    October,
    [Display(Name = "November")]
    November,
    [Display(Name = "December")]
    December
}

public class SearchPersonalViewModel
{
    public Personal Personal { get; set; }
    public TimeOffApplication TimeOffApplication { get; set; }

    [DisplayName("Active application")]
    public bool ActiveApplication { get; set; }
    public Months Months { get; set; }
}