using SimUDuck.DuckBehavior.DanceBehavior;
using SimUDuck.DuckBehavior.FlyBehavior;
using SimUDuck.DuckBehavior.MakeSoundBehavior;

namespace SimUDuck
{
    public class DecoyDuck : Duck
    {
        public DecoyDuck()
            : base( new FlyNoWay(), new Quack(), new NoDance() )
        {
        }
    }
}
