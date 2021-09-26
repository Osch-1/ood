using NUnit.Framework;
using WeatherStationPro.Observable;
using WeatherStationProTests.SubscriberStubs;

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

        [Test]
        public void Observable_Notify_SubscribersWithPriority_CallsUpdateInPriorityOrder()
        {
            //Arrange
            Observable<int> observable = new();
            PrioritizedSubscriber sub1 = new( "Sub to be called sixth" );
            PrioritizedSubscriber sub2 = new( "Sub to be called fifth" );
            PrioritizedSubscriber sub3 = new( "Sub to be called fourth" );
            PrioritizedSubscriber sub4 = new( "Sub to be called third" );
            PrioritizedSubscriber sub5 = new( "Sub to be called second" );
            PrioritizedSubscriber sub6 = new( "Sub to be called first" );
            PrioritizedSubscriber sub7 = new( "Sub to be called last" );


            observable.Subscribe( sub4, 4 );
            observable.Subscribe( sub6, 5 );
            observable.Subscribe( sub2, 2 );
            observable.Subscribe( sub3, 3 );
            observable.Subscribe( sub1, 1 );
            observable.Subscribe( sub5, 5 );
            observable.Subscribe( sub7 );

            //Act
            observable.Notify();

            //Assert
            Assert.That( PrioritizedSubscriber.UpdateMethodInvokationLog[ 0 ], Is.EqualTo( "Sub to be called first" ) );
            Assert.That( PrioritizedSubscriber.UpdateMethodInvokationLog[ 1 ], Is.EqualTo( "Sub to be called second" ) );
            Assert.That( PrioritizedSubscriber.UpdateMethodInvokationLog[ 2 ], Is.EqualTo( "Sub to be called third" ) );
            Assert.That( PrioritizedSubscriber.UpdateMethodInvokationLog[ 3 ], Is.EqualTo( "Sub to be called fourth" ) );
            Assert.That( PrioritizedSubscriber.UpdateMethodInvokationLog[ 4 ], Is.EqualTo( "Sub to be called fifth" ) );
            Assert.That( PrioritizedSubscriber.UpdateMethodInvokationLog[ 5 ], Is.EqualTo( "Sub to be called sixth" ) );
            Assert.That( PrioritizedSubscriber.UpdateMethodInvokationLog[ 6 ], Is.EqualTo( "Sub to be called last" ) );
        }
    }

}