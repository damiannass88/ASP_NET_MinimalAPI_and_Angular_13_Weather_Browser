 namespace MinimalAPI_Weather_Browser;

public class Weather
{ 
    public Guid Id { get; set; }
    public string Location { get; set; }
    private string _temperature; 
    public string Temperature
    {
        get { return _temperature; }   
        set { _temperature = value.Contains("°C") ? value : value + " °C"; }
    }
    private string _wind;
    public string Wind {
        get { return _wind; }
        set { _wind = value.Contains("km/h") ? value : value + " km/h"; }
    }
    public string Cloudiness { get; set; }
    public string Icon { get; set; }
}