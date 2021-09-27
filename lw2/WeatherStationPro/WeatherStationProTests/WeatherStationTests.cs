using NUnit.Framework;
using WeatherStationPro;
using WeatherStationProTests.SubscriberStubs;

namespace WeatherStationProTests
{
    public class WeatherStationTests
    {
        [Test]
        public void WeatherStation_Notify_SubscriberWithSourceTracker_ObserverCorrectlySendsItsName()
        {
            //Arrange
            string inStationName = "Inside staion";
            string outStationName = "Outside staion";
            WeatherStation wt1 = new( inStationName );
            WeatherStation wt2 = new( outStationName );
            SourceTrackingSubscriber sub1 = new();
            SourceTrackingSubscriber sub2 = new();

            wt1.Subscribe( sub1 );
            wt1.Subscribe( sub2 );
            wt2.Subscribe( sub1 );

            //Act
            wt1.SetMeasurments( 1, 2, 3, 4, 5 );
            wt2.SetMeasurments( 1, 2, 3, 4, 5 );

            //Assert
            Assert.That( sub1.UpdatedBy[ 0 ], Is.EqualTo( inStationName ) );
            Assert.That( sub1.UpdatedBy[ 1 ], Is.EqualTo( outStationName ) );
            Assert.That( sub2.UpdatedBy[ 0 ], Is.EqualTo( inStationName ) );
        }
    }
}
