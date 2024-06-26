namespace Application.Client.Features.Publishers.GetPublisher;

public record GetPublisherResponse
{
    public Guid Id { get; init; }
    public Guid LocationId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public bool IsActive { get; init; }

    public GetPublisherResponseLocation? Location { get; init; }
}

public record GetPublisherResponseLocation
{
    public Guid Id { get; init; }
    public required string Address { get; init; }
    public bool IsActive { get; init; }
    public required string Latitude { get; init; }
    public required string Longitude { get; init; }

    public GetPublisherResponseCity? City { get; init; }
    public GetPublisherResponseCountry? Country { get; init; }
}

public record GetPublisherResponseCity
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}

public record GetPublisherResponseCountry
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}