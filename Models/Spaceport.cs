namespace Space.Models;

public class Spaceport
{
    private string location;
    public string Location
    {
        get { return location; }
        set
        {
            location = value;
            SetLatitude();
        }
    }

    private float latitude;
    public float Latitude
    {
        get { return latitude; }
        private set { latitude = value; }
    }

    public string? LaunchBestDate { get; set; }

    // Method to set latitude based on location
    private void SetLatitude()
    {
        latitude = Location.ToLower() switch
        {
            "kourou,french guiana" => 5.1574f,
            "cape canaveral,usa" => 28.3922f,
            "kodiak,usa" => 57.7900f,
            "tanegashima,japan" => 30.6096f,
            "mahia,new zealand" => 39.0806f,
            _ => float.MaxValue,
        };
    }
}
