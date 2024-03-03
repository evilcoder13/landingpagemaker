using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace landingpagemaker.Models;

public class LandingPageStat
{
    public LandingPageStat()
    {
        TotalVisits = 0;
        TotalActions = 0;
    }
    public int Id { get; set; }
    public int LandingPageId { get; set; }
    [ForeignKey("LandingPageId")]
    public LandingPage? LandingPage { get; set; } // Navigation property
    public int TotalVisits { get; set; }
    public int TotalActions { get; set; }
    public float ConversionRate { get {
        if(TotalActions==0) return 0;
        else return TotalVisits/TotalActions;
    } }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
}