namespace SimUDuckWithFunc
{
    public class MallardDuck : Duck
    {
        public MallardDuck()
            : base( FlyBehaviors.FlyWithWings, MakeSoundBehaviors.Squeak, DanceBehaviors.DanceWaltz )
        {

        }
    }
}
