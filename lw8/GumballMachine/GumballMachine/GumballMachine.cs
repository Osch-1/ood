using GumballMachine.States;

namespace GumballMachine
{
    public class CGumballMachine : IGumballMachineContext, IGumballMachine
    {
        private int _ballsCount = 0;
        private NoQuarterState _noQuarterState;
        private HasQuarterState _hasQuarterState;
        private SoldState _soldState;
        private SoldOutState _soldOutState;
        private IState _currentState;

        public CGumballMachine( int ballsCount )
        {
            if ( _ballsCount < 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( ballsCount ), "ballsCount must be non-negative" );
            }

            _ballsCount = ballsCount;
            _noQuarterState = new( this );
            _hasQuarterState = new( this );
            _soldState = new( this );
            _soldOutState = new( this );

            if ( _ballsCount == 0 )
            {
                _currentState = _soldOutState;
            }
            else
            {
                _currentState = _noQuarterState;
            }
        }

        public void InsertQuarter()
        {
            _currentState.InsertQuarter();
        }

        public void EjectQuarter()
        {
            _currentState.EjectQuarter();
        }

        public void TurnCrank()
        {
            _currentState.TurnCrank();
            _currentState.Dispense();
        }

        #region IGumballMachineContext
        public int BallsCount => _ballsCount;

        public void ReleaseBall()
        {
            if ( _ballsCount != 0 )
            {
                Console.WriteLine( $"A gumball comes rolling out of the slot...{Environment.NewLine}" );
                --_ballsCount;
            }
            else
            {
                throw new InvalidOperationException( $"Trying to release ball with {_ballsCount} inside" );
            }
        }

        public void SetNoQuarterState()
        {
            _currentState = _noQuarterState;
        }

        public void SetHasQuarterState()
        {
            _currentState = _hasQuarterState;
        }

        public void SetSoldState()
        {
            _currentState = _soldState;
        }

        public void SetSoldOutState()
        {
            _currentState = _soldOutState;
        }
        #endregion

        public override string ToString()
        {
            return $"Current state is: {_currentState}. Balls count: {_ballsCount}";
        }
    }
}
