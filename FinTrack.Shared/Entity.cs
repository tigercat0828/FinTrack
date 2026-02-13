using System.ComponentModel.DataAnnotations;
namespace FinTrack.Shared;

public record CostLog(
    [property: Key] int Id, 
    string Item, 
    string Description, 
    decimal Amount, 
    DateTime Date
);
public record Asset(
    [property: Key] int Id,
     string Name, 
     decimal Value, 
     DateTime AcquisitionDate
);