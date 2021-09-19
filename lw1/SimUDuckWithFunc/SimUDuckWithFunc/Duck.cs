using System;

namespace SimUDuckWithFunc
{
    public class Duck
    {
        private Action _flyBehavior;
        private Action _makeSoundBehavior;
        private Action _danceBehavior;

        public Action FlyBehavior
        {
            get => _flyBehavior;
            set => _flyBehavior = value;
        }

        public Action MakeSoundBehavior
        {
            get => _makeSoundBehavior;
            set => _makeSoundBehavior = value;
        }

        public Action DanceBehavior
        {
            get => _danceBehavior;
            set => _danceBehavior = value;
        }

        public Duck()
        {

        }

        public Duck( Action flyBehavior, Action makeSoundBehavior, Action danceBehavior )
        {
            _flyBehavior = flyBehavior;
            _makeSoundBehavior = makeSoundBehavior;
            _danceBehavior = danceBehavior;
        }

        public void MakeSound()
        {
            MakeSoundBehavior?.Invoke();
        }

        public void Fly()
        {
            FlyBehavior?.Invoke();
        }

        public void Dance()
        {
            DanceBehavior?.Invoke();
        }

        public void Swim()
        {
            Console.WriteLine( "Swimming..." );
        }

        public void Draw()
        {
            Console.WriteLine( "Drawing duck, for some reason it draws itself..." );
        }
    }
}
