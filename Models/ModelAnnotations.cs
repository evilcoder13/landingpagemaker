using System.ComponentModel.DataAnnotations;

namespace landingpagemaker.Models;


public class NotAllowKeywordsAttribute : ValidationAttribute
{
    private readonly string[] _keywords;

    public NotAllowKeywordsAttribute()
    {
        ConfigurationManager cm = new ConfigurationManager();
        
        _keywords = cm.GetValue<string>("FilterKeywords","").Split(',');
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            var fieldValue = value.ToString();
            foreach (var keyword in _keywords)
            {
                if (fieldValue.Contains(keyword))
                {
                    return new ValidationResult($"The field {validationContext.DisplayName} cannot contain the keyword {keyword}.");
                }
            }
        }

        return ValidationResult.Success;
    }
}