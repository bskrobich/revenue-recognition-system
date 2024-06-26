using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionSystem.Validations;

public class RequiredIfAttribute : ValidationAttribute
{
    private readonly string _otherPropertyName;
    private readonly object _otherPropertyValue;

    public RequiredIfAttribute(string otherPropertyName, object otherPropertyValue)
    {
        _otherPropertyName = otherPropertyName;
        _otherPropertyValue = otherPropertyValue;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var otherProperty = validationContext.ObjectType.GetProperty(_otherPropertyName);
        if (otherProperty == null)
            throw new ArgumentException("Property with this name not found");

        var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance);

        if (otherPropertyValue == null || otherPropertyValue.Equals(_otherPropertyValue))
        {
            if (value == null)
                return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}
