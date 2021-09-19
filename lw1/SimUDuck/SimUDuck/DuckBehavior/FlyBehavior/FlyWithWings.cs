using System;
using SimUDuck.Trackers.FlyTrackers;

namespace SimUDuck.DuckBehavior.FlyBehavior
{
    //При необходимости можно вынести IFlyCountBehavior/ICountBehaviour.
    //Можно создать фабрику поведений и обернуть их в фабркиу уток, передавать внутрь конфигурацию нужной утки и получать верную
    //Декоратор
    public class FlyWithWings : IFlyBehavior
    {
        private readonly IFlyTrackBehavior _flyTrackBehavior = new IncrementalFlyTracker();

        public void Fly()
        {
            Console.WriteLine( "Flying with wings" );
            _flyTrackBehavior.OnFly();
        }
    }
}
