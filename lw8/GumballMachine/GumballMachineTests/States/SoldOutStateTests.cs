using System;
using NUnit.Framework;
using GumballMachine;
using GumballMachine.States;

namespace GumballMachineTests.States
{
    public class SoldOutStateTests : StateTestsBase
    {
        [Test]
        public void SoldOutState_Ctor_Null_ThrowsArgumentNullException()
        {
            //Arrange
            SoldOutState state;

            //Act
            void CallSoldOutStateCtorWithNullArgument() => state = new SoldOutState( null );

            //Assert
            Assert.Throws<ArgumentNullException>( CallSoldOutStateCtorWithNullArgument );
        }

        [Test]
        public void SoldOutState_InsertQuarter_OutputsCorrectMessage()
        {
            //Arrange
            CGumballMachine gbm = new( 2 );
            SoldOutState state = new SoldOutState( gbm );

            //Act
            state.InsertQuarter();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"Machine is sold out{Environment.NewLine}{Environment.NewLine}" ) );
        }

        [Test]
        public void SoldOutState_EjectQuarter_OutputsCorrectMessage()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            SoldOutState state = new SoldOutState( gbm );

            //Act
            state.EjectQuarter();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"You can't eject, there is no inserted quarter{Environment.NewLine}{Environment.NewLine}" ) );
        }

        [Test]
        public void SoldOutState_TurnCrank_OutputsCorrectMessage()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            SoldOutState state = new SoldOutState( gbm );

            //Act
            state.TurnCrank();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"You turned the crank, but there is no gumball{Environment.NewLine}{Environment.NewLine}" ) );
        }

        [Test]
        public void SoldOutState_Dispense_OutputsCorrectMessage()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            SoldOutState state = new SoldOutState( gbm );

            //Act
            state.Dispense();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"No gumball to be dispensed{Environment.NewLine}{Environment.NewLine}" ) );
        }

        [Test]
        public void SoldOutState_ToString_ReturnsCorrectString()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            SoldOutState state = new SoldOutState( gbm );

            //Act
            var result = state.ToString();

            //Assert
            Assert.That( result, Is.EqualTo( "Sold out" ) );
        }
    }
}
