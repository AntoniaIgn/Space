namespace Space.Models;

public class SpaceportsResponse
{
    public required Dictionary<Spaceport, float> SpaceportsData { get; set; }
    public required string FolderPath { get; set; }
}