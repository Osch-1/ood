using WeatherStationPro.WeatherStations;

namespace WeatherStationPro
{
    class Program
    {
        static void Main( string[] args )
        {
            InsideWeatherStation wt = new();
            InsideWeatherStation wt2 = new();
            StatisticsDisplay sdp = new();

            wt.Subscribe( sdp );
            wt2.Subscribe( sdp );
            wt.SetMeasurments( 1, 2, 3, 4, 5 );
            wt.SetMeasurments( 2, 3, 4, 5, 6 );
            wt.SetMeasurments( 3, 4, 5, 6, 7 );
            wt.SetMeasurments( 4, 5, 6, 7, 8 );
            wt.SetMeasurments( 5, 6, 7, 8, 9 );
            wt.SetMeasurments( 6, 7, 8, 9, 10 );
            wt.SetMeasurments( 7, 8, 9, 10, 11 );
            wt.SetMeasurments( 8, 9, 10, 11, 12 );

            wt2.SetMeasurments( 1, 2, 3, 4, 5 );
            wt2.SetMeasurments( 2, 3, 4, 5, 6 );
            wt2.SetMeasurments( 3, 4, 5, 6, 7 );
            wt2.SetMeasurments( 4, 5, 6, 7, 8 );
            wt2.SetMeasurments( 5, 6, 7, 8, 9 );
            wt2.SetMeasurments( 6, 7, 8, 9, 10 );
            wt2.SetMeasurments( 7, 8, 9, 10, 11 );
            wt2.SetMeasurments( 8, 9, 10, 11, 12 );
        }
    }
}
