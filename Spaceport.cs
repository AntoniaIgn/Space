using System.ComponentModel.DataAnnotations;

namespace Space;

public class Spaceport
{
    [Required]
    public string Location { get; set; }

    /*private float latitude;
    [Required]
    public float Latitude { get => latitude; set => latitude = (float)value; }*/     //not neccesery a higher precision

    public string? LaunchBestDate { get; set; }
}