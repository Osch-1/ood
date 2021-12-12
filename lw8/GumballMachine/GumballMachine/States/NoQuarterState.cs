namespace GumballMachine.States
{
    public class NoQuarterState : IState
    {
        private readonly IGumballMachineContext _context;

        public NoQuarterState( IGumballMachineContext gumballMachine )
        {
            _context = gumballMachine ?? throw new ArgumentNullException( nameof( gumballMachine ) );
        }

        public void InsertQuarter()
        {
            _context.SetHasQuarterState();
            Console.WriteLine( $"You inserted a quarter{Environment.NewLine}" );
        }

        public void EjectQuarter()
        {
            _context.SetNoQuarterState();
            Console.WriteLine( $"You ejected a quarter{Environment.NewLine}" );
        }

        public void TurnCrank()
        {
            Console.WriteLine( $"You turned the crank, but there is no quarter inside{Environment.NewLine}" );
        }

        public void Dispense()
        {
            Console.WriteLine( $"Insert the quarter to receive a ball{Environment.NewLine}" );
        }

        public override string ToString()
        {
            return $"Waiting for quarter";
        }
    }
}
