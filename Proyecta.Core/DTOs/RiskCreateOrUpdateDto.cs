using System.ComponentModel.DataAnnotations;
using Proyecta.Core.Entities.Validators;

namespace Proyecta.Core.DTOs;

public record RiskCreateOrUpdateDto : IValidatableObject
{
    public int Code { get; set; }
    public string Name { get; set; }
    public Guid Category { get; set; }
    public int Type { get; set; }
    public Guid Owner { get; set; }
    public int Phase { get; set; }
    public int Manageability { get; set; }
    public Guid Treatment { get; set; }
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public Boolean State { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validationResult = new List<ValidationResult>();
        validationResult.AddRange(TextValidator.ValidateName(Name, nameof(Name)));

        return validationResult;
    }
}