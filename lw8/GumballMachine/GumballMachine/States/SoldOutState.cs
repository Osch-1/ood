namespace GumballMachine.States
{
    public class SoldOutState : IState
    {
        private IGumballMachineContext _context;

        public SoldOutState( IGumballMachineContext context )
        {
            _context = context ?? throw new ArgumentNullException( nameof( context ) );
        }

        public void InsertQuarter()
        {
            Console.WriteLine( $"Machine is sold out{Environment.NewLine}" );
        }

        public void EjectQuarter()
        {
            Console.WriteLine( $"You can't eject, there is no inserted quarter{Environment.NewLine}" );
        }

        public void TurnCrank()
        {
            Console.WriteLine( $"You turned the crank, but there is no gumball{Environment.NewLine}" );
        }

        public void Dispense()
        {
            Console.WriteLine( $"No gumball to be dispensed{Environment.NewLine}" );
        }

        public override string ToString()
        {
            return $"Sold out";
        }
    }
}
