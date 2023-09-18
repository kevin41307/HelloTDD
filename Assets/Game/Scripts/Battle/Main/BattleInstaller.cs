using Game.Scripts.Battle.Misc;
using Game.Scripts.Players.Handlers;
using Game.Scripts.Players.Main;
using Zenject;
namespace Game.Scripts.Battle.Main
{
    public class BattleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IDeltaTimeProvider>().To<DeltaTimeProvider>().AsSingle();
        }
    }

}