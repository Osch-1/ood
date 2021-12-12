namespace GumballMachine
{
    public interface IGumballMachineContext
    {
        public int BallsCount
        {
            get;
        }

        public void ReleaseBall();
        public void SetNoQuarterState();
        public void SetHasQuarterState();
        public void SetSoldState();
        public void SetSoldOutState();
    }
}
