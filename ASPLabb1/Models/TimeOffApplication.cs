using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPLabb1.Models;

public enum TimeOffType
{
    [Display(Name = "Sick leave")]
    Sickleave,
    [Display(Name = "Childcare")]
    Childcare,
    [Display(Name = "Vacation")]
    Vacation,
    [Display(Name = "Zombie Apocalypse")]
    ZombieApocalypse,
    [Display(Name = "Other")]
    Other
}

public class TimeOffApplication
{
    public int Id { get; set; }

    [DisplayName("Time off type")]
    public TimeOffType TypeName { get; set; }

    [DisplayName("Start date")]
    public DateTime StartDate { get; set; }

    [DisplayName("End date")]
    public DateTime EndDate { get; set; }

    [DisplayName("Application date")]
    public DateTime ApplicationDate { get; set; } = DateTime.Now;

    public int PersonalId { get; set; }
    public Personal? Personal { get; set; }
}