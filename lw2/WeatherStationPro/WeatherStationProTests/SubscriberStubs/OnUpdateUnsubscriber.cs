using WeatherStationPro;

namespace WeatherStationProTests.SubscriberStubs
{
    public class OnUpdateUnsubscriber : IObserver<int>
    {
        private readonly IObservable<int> _subject;
        public static int UpdateCalledCount
        {
            get;
            set;
        }

        public OnUpdateUnsubscriber( IObservable<int> subject )
        {
            _subject = subject;
        }

        public void Update( string source, int data )
        {
            UpdateCalledCount++;
            _subject.Unsubscribe( this );
        }

        public static void Tune()
        {
            UpdateCalledCount = 0;
        }
    }
}