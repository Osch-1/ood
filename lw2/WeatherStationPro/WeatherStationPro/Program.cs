namespace WeatherStationPro
{
    class Program
    {
        static void Main( string[] args )
        {
            WeatherStation wt = new( "some station" );
            StatisticsDisplay sdp = new();

            wt.Subscribe( sdp );
            wt.SetMeasurments( 1, 2, 3, 4, 5 );
            wt.SetMeasurments( 2, 3, 4, 5, 6 );
            wt.SetMeasurments( 3, 4, 5, 6, 7 );
            wt.SetMeasurments( 4, 5, 6, 7, 8 );
            wt.SetMeasurments( 5, 6, 7, 8, 9 );
            wt.SetMeasurments( 6, 7, 8, 9, 10 );
            wt.SetMeasurments( 7, 8, 9, 10, 11 );
            wt.SetMeasurments( 8, 9, 10, 11, 12 );
        }
    }
}
