using System;

namespace WeatherStationPro.StatisticCounter.StatisticsDisplayStrategy
{
    public class CardinalPointStatisticsDisplayStrategy : IAverageStatisticsDisplayStrategy
    {
        private const string _north = "Север";
        private const string _west = "Восток";
        private const string _south = "Юг";
        private const string _east = "Запад";
        private const string _southWest = "Юго-Восток";
        private const string _northWest = "Северо-Восток";
        private const string _southEast = "Юго-Запад";
        private const string _northEast = "Северо-Запад";

        private readonly string _name;

        public CardinalPointStatisticsDisplayStrategy( string name )
        {
            _name = name;
        }

        public void Display( double min, double max, double average )
        {
            Console.WriteLine( $"Average {_name}: {GetCardinalPointName( average )}" );
        }

        private string GetCardinalPointName( double degree )
        {
            var normalizedDegree = NormalizeDegree( degree );

            if ( normalizedDegree == 0 )
                return _north;

            if ( normalizedDegree == 90 )
                return _west;

            if ( normalizedDegree == 180 )
                return _south;

            if ( normalizedDegree == 270 )
                return _east;

            if ( normalizedDegree > 0 && normalizedDegree < 90 )
                return _northWest;

            if ( normalizedDegree > 90 && normalizedDegree < 180 )
                return _southWest;

            if ( normalizedDegree > 180 && normalizedDegree < 270 )
                return _southEast;

            return _northEast;
        }

        private double NormalizeDegree( double degree )
        {
            return degree % 360;
        }
    }
}
