namespace SimUDuckWithFunc
{
    public class RedheadDuck : Duck
    {
        public RedheadDuck()
            : base( FlyBehaviors.FlyWithWings, MakeSoundBehaviors.Quack, DanceBehaviors.DanceMinuet )
        {
        }
    }
}
