using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherStationPro.Entities;
using WeatherStationPro.Observable;

namespace WeatherStationPro.WeatherStations
{
    public class DisjointSensorsWeatherStation : Observable<WeatherSubscriptionInfo>
    {
        public DisjointSensorsWeatherStation()
            : base( "Outside weather station with disjoint sensors" )
        {
        }


    }
}
