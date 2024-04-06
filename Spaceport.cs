namespace Space;

public class Spaceport
{
    public string Location { get; set; }

    public float Latitude { get; set; }     //not neccesery a higher precision

    public string? LaunchBestDate { get; set; }

    public Spaceport(string location, string? launchBestDate)
    {
        Location = location;
        SetLatitude();
        LaunchBestDate = launchBestDate;
    }

    public void SetLatitude()
    {
        Latitude = Location.ToLower() switch
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

