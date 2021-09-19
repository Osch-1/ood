using SimUDuck.DuckBehavior.FlyBehavior;
using SimUDuck.DuckBehavior.MakeSoundBehavior;
using SimUDuck.DuckBehavior.DanceBehavior;

namespace SimUDuck
{
    public class RedheadDuck : Duck
    {
        public RedheadDuck()
            : base( new FlyWithWings(), new Quack(), new DanceMinuet() )
        {
        }
    }
}
