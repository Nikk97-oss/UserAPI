namespace UserAPI;

public class User {
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string userName { get; set; }
    public required string Email { get; set; }
    public required Address Address { get; set; }
    public required string Phone { get; set; }
    public required string website { get; set; }
    public required Company company { get; set; }
}