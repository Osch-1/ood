using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStationPro.Entities
{
    public class WeatherSubscriptionInfo
    {
        public MeasureType MeasureType { get; set; }
        public double Value { get; set; }
    }
}
