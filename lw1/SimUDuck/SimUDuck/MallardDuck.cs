using SimUDuck.DuckBehavior.DanceBehavior;
using SimUDuck.DuckBehavior.FlyBehavior;
using SimUDuck.DuckBehavior.MakeSoundBehavior;

namespace SimUDuck
{
    public class MallardDuck : Duck
    {
        public MallardDuck()
            : base( new FlyWithWings(), new Squeak(), new DanceWaltz() )
        {

        }
    }
}
