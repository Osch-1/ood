using System;
using GumballMachine;
using GumballMachine.States;
using NUnit.Framework;

namespace GumballMachineTests.States
{
    public class NoQuarterStateTests : StateTestsBase
    {
        [Test]
        public void NoQuarterState_Ctor_Null_ThrowsArgumentNullException()
        {
            //Arrange
            NoQuarterState state;

            //Act
            void CallNoQuarterStateCtorWithNullArgument() => state = new NoQuarterState( null );

            //Assert
            Assert.Throws<ArgumentNullException>( CallNoQuarterStateCtorWithNullArgument );
        }

        [Test]
        public void NoQuarterState_InsertQuarter_OutputsCorrectMessageAndSetsCorrectGumballMachineState()
        {
            //Arrange
            CGumballMachine gbm = new( 2 );
            NoQuarterState state = new NoQuarterState( gbm );

            //Act
            state.InsertQuarter();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"You inserted a quarter{Environment.NewLine}{Environment.NewLine}" ) );
            Assert.That( gbm.ToString(), Is.EqualTo( $"Current state is: Waiting for crank to be turned. Balls count: 2" ) );
        }

        [Test]
        public void NoQuarterState_EjectQuarter_OutputsCorrectMessageAndSetsCorrectGumballMachineState()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            NoQuarterState state = new NoQuarterState( gbm );

            //Act
            state.EjectQuarter();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"You ejected a quarter{Environment.NewLine}{Environment.NewLine}" ) );
            Assert.That( gbm.ToString(), Is.EqualTo( "Current state is: Waiting for quarter. Balls count: 2" ) );
        }

        [Test]
        public void NoQuarterState_TurnCrank_OutputsCorrectMessage()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            NoQuarterState state = new NoQuarterState( gbm );

            //Act
            state.TurnCrank();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"You turned the crank, but there is no quarter inside{Environment.NewLine}{Environment.NewLine}" ) );
        }

        [Test]
        public void NoQuarterState_Dispense_OutputsCorrectMessage()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            NoQuarterState state = new NoQuarterState( gbm );

            //Act
            state.Dispense();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"Insert the quarter to receive a ball{ Environment.NewLine}{ Environment.NewLine}" ) );
        }

        [Test]
        public void NoQuarterState_ToString_ReturnsCorrectString()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            NoQuarterState state = new NoQuarterState( gbm );

            //Act
            var result = state.ToString();

            //Assert
            Assert.That( result, Is.EqualTo( "Waiting for quarter" ) );
        }
    }
}
