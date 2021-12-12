using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GumballMachine;
using GumballMachine.States;
using NUnit.Framework;

namespace GumballMachineTests.States
{
    public class SoldStateTests : StateTestsBase
    {
        [Test]
        public void SoldState_Ctor_Null_ThrowsArgumentNullException()
        {
            //Arrange
            SoldState state;

            //Act
            void CallSoldStateCtorWithNullArgument() => state = new SoldState( null );

            //Assert
            Assert.Throws<ArgumentNullException>( CallSoldStateCtorWithNullArgument );
        }

        [Test]
        public void SoldState_InsertQuarter_OutputsCorrectMessage()
        {
            //Arrange
            CGumballMachine gbm = new( 2 );
            SoldState state = new SoldState( gbm );

            //Act
            state.InsertQuarter();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"Wait for sell operation to be completed...{Environment.NewLine}{Environment.NewLine}" ) );
        }

        [Test]
        public void SoldState_EjectQuarter_OutputsCorrectMessage()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            SoldState state = new SoldState( gbm );

            //Act
            state.EjectQuarter();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"Crank has already been turned, wait for sell opertation to be completed...{Environment.NewLine}{Environment.NewLine}" ) );
        }

        [Test]
        public void SoldState_TurnCrank_OutputsCorrectMessage()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            SoldState state = new SoldState( gbm );

            //Act
            state.TurnCrank();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"Crank has already been turned, wait for sell opertation to be completed...{Environment.NewLine}{Environment.NewLine}" ) );
        }

        [Test]
        public void SoldState_Dispense_OutputsCorrectMessageAndSetsNoQuarterStateIfGumballNotEmptyAndHasBallsAfterDispense()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            SoldState state = new SoldState( gbm );

            //Act
            state.Dispense();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"A gumball comes rolling out of the slot...{Environment.NewLine}{Environment.NewLine}" ) );
            Assert.That( gbm.ToString(), Is.EqualTo( $"Current state is: Waiting for quarter. Balls count: 1" ) );
        }

        [Test]
        public void SoldState_Dispense_OutputsCorrectMessageIfGumballNotEmptyAndHasNoBallsAfterDispense()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 1 );
            SoldState state = new SoldState( gbm );

            //Act
            state.Dispense();

            //Assert
            Assert.That( Output.ToString(), Is.EqualTo( $"A gumball comes rolling out of the slot...{Environment.NewLine}{Environment.NewLine}No balls left...{Environment.NewLine}{Environment.NewLine}" ) );
            Assert.That( gbm.ToString(), Is.EqualTo( $"Current state is: Sold out. Balls count: 0" ) );
        }

        [Test]
        public void SoldState_Dispense_ThrowsInvalidOperationExceptionIfGumballIsEmpty()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 0 );
            SoldState state = new SoldState( gbm );

            //Act
            void CallDispenseWithEmptyGumballMachine() => state.Dispense();

            //Assert
            Assert.Throws<InvalidOperationException>( CallDispenseWithEmptyGumballMachine );
        }

        [Test]
        public void SoldState_ToString_ReturnsCorrectString()
        {
            //Arrange
            CGumballMachine gbm = new CGumballMachine( 2 );
            SoldState state = new SoldState( gbm );

            //Act
            var result = state.ToString();

            //Assert
            Assert.That( result, Is.EqualTo( "Delivering the gumball" ) );
        }
    }
}
