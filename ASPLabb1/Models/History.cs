using System.ComponentModel;

namespace ASPLabb1.Models;

public class History
{
	public int Id { get; set; }
	public int PersonalId { get; set; }
	public int TimeOffApplicationId { get; set; }

	[DisplayName("Application status")]
	public bool ApplicationStatus { get; set; }
	public Personal? Personal { get; set; }

	[DisplayName("Time off application")]
	public TimeOffApplication? TimeOffApplication { get; set; }

}