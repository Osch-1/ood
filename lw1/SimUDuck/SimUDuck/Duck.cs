using System;
using SimUDuck.DuckBehavior.DanceBehavior;
using SimUDuck.DuckBehavior.FlyBehavior;
using SimUDuck.DuckBehavior.MakeSoundBehavior;

namespace SimUDuck
{
    public class Duck
    {
        private IFlyBehavior _flyBehavior;
        private IMakeSoundBehavior _makeSoundBehavior;
        private IDanceBehavior _danceBehavior;

        public IFlyBehavior FlyBehavior
        {
            get => _flyBehavior;
            set => _flyBehavior = value;
        }

        public IMakeSoundBehavior MakeSoundBehavior
        {
            get => _makeSoundBehavior;
            set => _makeSoundBehavior = value;
        }

        public IDanceBehavior DanceBehavior
        {
            get => _danceBehavior;
            set => _danceBehavior = value;
        }

        public Duck()
        {
            _flyBehavior = new FlyWithWings();
            _makeSoundBehavior = new Quack();
            _danceBehavior = new NoDance();
        }

        public Duck( IFlyBehavior flyBehavior, IMakeSoundBehavior makeSoundBehavior, IDanceBehavior danceBehavior )
        {
            _flyBehavior = flyBehavior;
            _makeSoundBehavior = makeSoundBehavior;
            _danceBehavior = danceBehavior;
        }

        public void MakeSound()
        {
            MakeSoundBehavior?.Quack();
        }

        public void Fly()
        {
            FlyBehavior?.Fly();
        }

        public void Dance()
        {
            DanceBehavior?.Dance();
        }

        public void Swim()
        {
            Console.WriteLine( "Swimming..." );
        }

        public void Draw()
        {
            Console.WriteLine( "Drawing duck" );
        }
    }
}
