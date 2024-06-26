using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionSystem.Validations;

public class DateRangeAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;
    private readonly int _minDays;
    private readonly int _maxDays;

    public DateRangeAttribute(string comparisonProperty, int minDays, int maxDays)
    {
        _comparisonProperty = comparisonProperty;
        _minDays = minDays;
        _maxDays = maxDays;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("End date is required.");
        }

        var endDate = (DateTime)value;

        var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
        if (property == null)
        {
            throw new ArgumentException("Property with this name not found");
        }

        var startDate = (DateTime)property.GetValue(validationContext.ObjectInstance);

        var difference = (endDate - startDate).TotalDays;

        if (difference < _minDays || difference > _maxDays)
        {
            return new ValidationResult($"The date range between StartDate and EndDate must be between {_minDays} and {_maxDays} days.");
        }

        return ValidationResult.Success;
    }
}
