namespace GumballMachine.States
{
    public class SoldState : IState
    {
        private IGumballMachineContext _context;

        public SoldState( IGumballMachineContext gumballMachineContext )
        {
            _context = gumballMachineContext ?? throw new ArgumentNullException( nameof( gumballMachineContext ) );
        }

        public void InsertQuarter()
        {
            Console.WriteLine( $"Wait for sell operation to be completed...{Environment.NewLine}" );
        }

        public void EjectQuarter()
        {
            Console.WriteLine( $"Crank has already been turned, wait for sell opertation to be completed...{Environment.NewLine}" );
        }

        public void TurnCrank()
        {
            Console.WriteLine( $"Crank has already been turned, wait for sell opertation to be completed...{Environment.NewLine}" );
        }

        public void Dispense()
        {
            _context.ReleaseBall();
            if ( _context.BallsCount == 0 )
            {
                Console.WriteLine( $"No balls left...{Environment.NewLine}" );
                _context.SetSoldOutState();
            }
            else
            {
                _context.SetNoQuarterState();
            }
        }

        public override string ToString()
        {
            return $"Delivering the gumball";
        }
    }
}
