using System;
using GumballMachine;
using GumballMachine.States;
using NUnit.Framework;

namespace GumballMachineTests.States
{
    public class HasQuarterStateTests : StateTestsBase
    {
        [Test]
        public void HasQuarterState_Ctor_Null_ThrowsArgumentNullException()
        {
            //Arrange
            HasQuarterState state;

            //Act
            void CallHasQuarterStateCtorWithNullArgument() => state = new HasQuarterState( null );

            //Assert
            Assert.Throws<ArgumentNullException>( CallHasQuarterStateCtorWithNullArgument );
        }

        [Test]
        public void HasQuarterState_InsertQuarter_OutputsCorrectMessage()
        {
            //Arrange
            HasQuarterState state = new HasQuarterState( new CGumballMachine( 2 ) );

            //Act
            state.InsertQuarter();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"Quarter already inserted{Environment.NewLine}{Environment.NewLine}" ) );
        }

        [Test]
        public void HasQuarterState_EjectQuarter_OutputsCorrectMessageAndSetsCorrectGumballMachineState()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            HasQuarterState state = new HasQuarterState( gbm );

            //Act
            state.EjectQuarter();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"You ejected a quarter{Environment.NewLine}{Environment.NewLine}" ) );
            Assert.That( gbm.ToString(), Is.EqualTo( "Current state is: Waiting for quarter. Balls count: 2" ) );
        }

        [Test]
        public void HasQuarterState_TurnCrank_OutputsCorrectMessageAndSetsCorrectGumballMachineState()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            HasQuarterState state = new HasQuarterState( gbm );

            //Act
            state.TurnCrank();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"Crank has been turned...{Environment.NewLine}{Environment.NewLine}" ) );
            Assert.That( gbm.ToString(), Is.EqualTo( $"Current state is: Delivering the gumball. Balls count: 2" ) );
        }

        [Test]
        public void HasQuarterState_Dispense_ThrowsInvalidOperationException()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            HasQuarterState state = new HasQuarterState( gbm );

            //Act
            void CallDispenseInHasQuarterState() => state.Dispense();

            //Assert
            Assert.Throws<InvalidOperationException>( CallDispenseInHasQuarterState, "Dispense method has been called in HasQuarterState" );
        }

        [Test]
        public void HasQuarterState_ToString_ReturnsCorrectString()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            HasQuarterState state = new HasQuarterState( gbm );

            //Act
            var result = state.ToString();

            //Assert
            Assert.That( result, Is.EqualTo( "Waiting for crank to be turned" ) );
        }
    }
}
