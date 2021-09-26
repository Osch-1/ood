using System;

namespace WeatherStationPro
{
    public class AverageStatisticsCounter : IStatisticsCounter
    {
        private string _name;
        private double _minimal;
        private double _maximal;
        private double _total;
        private int _accCount;

        public AverageStatisticsCounter( string name )
        {
            _name = name;
        }

        private double GetAvarage()
        {
            return _accCount == 0 ? 0 : _total / _accCount;
        }

        public void OnNewValue( double value )
        {
            if ( value > _maximal )
                _maximal = value;
            else if ( value < _minimal )
                _minimal = value;

            _total += value;
            _accCount++;
        }

        public void Display()
        {
            Console.WriteLine( $"Maximal {_name}: {_maximal:0.##}" );
            Console.WriteLine( $"Minimal {_name}: {_minimal:0.##}" );
            Console.WriteLine( $"Avarage {_name}: {GetAvarage():0.##}" );
        }
    }
}
