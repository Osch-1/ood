namespace GumballMachine.States
{
    public class HasQuarterState : IState
    {
        private IGumballMachineContext _context;

        public HasQuarterState( IGumballMachineContext gumballMachineContext )
        {
            _context = gumballMachineContext ?? throw new ArgumentNullException( nameof( gumballMachineContext ) );
        }

        public void InsertQuarter()
        {
            Console.WriteLine( $"Quarter already inserted{Environment.NewLine}" );
        }

        public void EjectQuarter()
        {
            _context.SetNoQuarterState();
            Console.WriteLine( $"You ejected a quarter{Environment.NewLine}" );
        }

        public void TurnCrank()
        {
            Console.WriteLine( $"Crank has been turned...{Environment.NewLine}" );
            _context.SetSoldState();
        }

        public void Dispense()
        {
            throw new InvalidOperationException( $"Dispense method has been called in {typeof( HasQuarterState )}" );
        }

        public override string ToString()
        {
            return $"Waiting for crank to be turned";
        }
    }
}
