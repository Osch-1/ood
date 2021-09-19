using System;

namespace WeatherStation
{
    public class Display : IObserver<WeatherInfo>
    {
        public void Update( WeatherInfo data )
        {
            Console.WriteLine( $"Current temperature: {data.Temperature:0.##}" );
            Console.WriteLine( $"Current humidity: {data.Humidity:0.##}" );
            Console.WriteLine( $"Current pressure: {data.Pressure:0.##}" );
            Console.WriteLine( $"-----------------------{Environment.NewLine}" );
        }
    }
}
