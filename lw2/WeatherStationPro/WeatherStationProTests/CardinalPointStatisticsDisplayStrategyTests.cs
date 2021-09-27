using System;
using System.IO;
using NUnit.Framework;
using WeatherStationPro.StatisticCounter.StatisticsDisplayStrategy;

namespace WeatherStationProTests
{
    public class CardinalPointStatisticsDisplayStrategyTests
    {
        [Test]
        public void CardinalPointStatisticsDisplayStrategy_Display_ValuesFromEachSector_CorrectOutput()
        {
            //Arrange
            CardinalPointStatisticsDisplayStrategy strategy = new( "" );

            //Act
            using StringWriter sw = new();
            Console.SetOut( sw );
            strategy.Display( 0, 12, 90 );
            strategy.Display( 120, 180, 200 );
            strategy.Display( 270, 290, 372 );
            strategy.Display( 270, 290, 372 );
            strategy.Display( -20, -90, -120 );
            strategy.Display( -180, -212, -270 );
            strategy.Display( -292, -360, 0 );

            //Assert
            var expected = "Minimal : Север\r\nMaximal : Северо-Восток\r\nAverage : Восток\r\nMinimal : Юго-Восток\r\nMaximal : Юг\r\nAverage : Юго-Запад\r\nMinimal : Запад\r\nMaximal : Северо-Запад\r\nAverage : Северо-Восток\r\nMinimal : Запад\r\nMaximal : Северо-Запад\r\nAverage : Северо-Восток\r\nMinimal : Северо-Запад\r\nMaximal : Северо-Запад\r\nAverage : Северо-Запад\r\nMinimal : Северо-Запад\r\nMaximal : Северо-Запад\r\nAverage : Северо-Запад\r\nMinimal : Северо-Запад\r\nMaximal : Север\r\nAverage : Север\r\n";
            Assert.That( sw.ToString(), Is.EqualTo( expected ) );
        }
    }
}
