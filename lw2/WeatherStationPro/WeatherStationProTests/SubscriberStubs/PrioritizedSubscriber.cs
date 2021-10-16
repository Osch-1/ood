using System.Collections.Generic;
using WeatherStationPro;

namespace WeatherStationProTests.SubscriberStubs
{
    public class PrioritizedSubscriber : IObserver<int>
    {
        public static List<string> UpdateMethodInvokationLog = new();

        public string Name { get; }

        public PrioritizedSubscriber( string name )
        {
            Name = name;
        }

        public void Update( string source, int data )
        {
            UpdateMethodInvokationLog.Add( Name );
        }
    }
}
