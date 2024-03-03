using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace landingpagemaker.Models;

public class LandingPage
{
    public LandingPage()
    {
        Description = "";
        Content = "";
        CategoryId = 0;
    }
    [Key]
    public int Id { get; set; }
    [Required, StringLength(150)]
    public string Name { get; set; }
    [StringLength(255)]
    public string Description { get; set; }
    [Required]
    public string Content { get; set; }
    public int CategoryId {get;set;} // 0: Template, 1-n: LandingPage
    public int Status { get; set; } // 1: Active, 0: Inactive, 2: Deleted
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public DateTime ExpiredOn { get; set; }

    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public IdentityUser User { get; set; } // Navigation property
    [ForeignKey("CategoryId")]
    public Category PageCategory { get; set; } // Navigation property
    public ICollection<LandingPageStat> LandingPageStats { get; set; } // Navigation property
}