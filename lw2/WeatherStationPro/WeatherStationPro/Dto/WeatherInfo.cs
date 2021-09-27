namespace WeatherStationPro.Dto
{
    public class WeatherInfo
    {
        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public double Pressure { get; set; }

        public double WindSpeed { get; set; }

        public double WindDirection { get; set; }

        public string Source { get; set; }
    }
}