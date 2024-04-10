using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPLabb1.Models;

public class Personal
{
    public int Id { get; set; }

    [DisplayName("Name")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Names have to be 3 - 100 in length")]
    public string Name { get; set; }
    public ICollection<History> Historys { get; set; } = new List<History>();
    public ICollection<TimeOffApplication> TimeOffApplications { get; set; } = new List<TimeOffApplication>();
}