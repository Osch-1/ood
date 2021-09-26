using NUnit.Framework;
using WeatherStation;

namespace WeatherStationTests
{
    public class ObservableTests
    {
        [SetUp]
        public void Setup()
        {
            OnUpdateUnsubscriber.Tune();
            CommonSubscriber.Tune();
        }

        [Test]
        public void Observable_Notify_WithSubscruberWhichUnsubsrcibesInUpdateMethod_DoesntThrowException()
        {
            //Arrange
            Observable<int> observable = new();
            OnUpdateUnsubscriber sub1 = new( observable );
            CommonSubscriber sub2 = new();
            CommonSubscriber sub3 = new();

            observable.Subscribe( sub1 );
            observable.Subscribe( sub2 );
            observable.Subscribe( sub3 );

            //Act
            observable.Notify();
            observable.Notify();

            //Assert
            Assert.AreEqual( 1, OnUpdateUnsubscriber.UpdateCalledCount );
            Assert.AreEqual( 4, CommonSubscriber.UpdateCalledCount );
        }
    }

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

        public void Update( int data )
        {
            UpdateCalledCount++;
            _subject.Unsubscribe( this );
        }

        public static void Tune()
        {
            UpdateCalledCount = 0;
        }
    }

    public class CommonSubscriber : IObserver<int>
    {
        public static int UpdateCalledCount
        {
            get;
            set;
        }

        public void Update( int data )
        {
            UpdateCalledCount++;
        }

        public static void Tune()
        {
            UpdateCalledCount = 0;
        }
    }
}