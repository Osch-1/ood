namespace SimUDuckWithFunc
{
    public class DecoyDuck : Duck
    {

        public DecoyDuck()
            : base( FlyBehaviors.FlyNoWay, MakeSoundBehaviors.MuteQuack, DanceBehaviors.NoDance )
        {
        }
    }
}
