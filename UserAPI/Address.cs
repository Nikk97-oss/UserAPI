namespace UserAPI;

public class Address {
    public required string Street { get; set; }
    public required string Suite { get; set; }
    public required string City { get; set; }
    public required string zipCode { get; set; }
    public required Geo Geo { get; set; } // Nota come Address "contiene" Geo
}