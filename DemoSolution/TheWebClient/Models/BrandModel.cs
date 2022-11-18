namespace TheWebClient.Models;

public class BrandModel
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Website { get; set; }
    public byte[]? Timestamp { get; set; }
}
