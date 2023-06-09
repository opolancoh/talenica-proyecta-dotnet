namespace Proyecta.Core.DTOs;

public record ApplicationUserBaseDto
{
    public string Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string UserName { get; init; }
}