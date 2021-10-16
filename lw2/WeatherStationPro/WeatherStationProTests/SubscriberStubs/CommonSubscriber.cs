using WeatherStationPro;

namespace WeatherStationProTests.SubscriberStubs
{
    public class CommonSubscriber : IObserver<int>
    {
        public static int UpdateCalledCount
        {
            get;
            set;
        }

        public void Update( string source, int data )
        {
            UpdateCalledCount++;
        }

        public static void Tune()
        {
            UpdateCalledCount = 0;
        }
    }
}
