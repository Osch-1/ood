using NUnit.Framework;
using WeatherStation;

namespace WeatherStationTests
{
    public class ObservableTests
    {
        [SetUp]
        public void Setup()
        {
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
            Assert.AreEqual( 5, AbstractSubscriber.UpdateCalledCount );
        }
    }

    public class AbstractSubscriber
    {
        public static int UpdateCalledCount
        {
            get;
            set;
        }
    }

    public class OnUpdateUnsubscriber : AbstractSubscriber, IObserver<int>
    {
        private readonly IObservable<int> _subject;

        public OnUpdateUnsubscriber( IObservable<int> subject )
        {
            _subject = subject;
        }

        public void Update( int data )
        {
            UpdateCalledCount++;
            _subject.Unsubscribe( this );
        }
    }

    public class CommonSubscriber : AbstractSubscriber, IObserver<int>
    {
        public void Update( int data )
        {
            UpdateCalledCount++;
        }
    }
}