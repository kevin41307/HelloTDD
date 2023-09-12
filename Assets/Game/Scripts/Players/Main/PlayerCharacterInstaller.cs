using Game.Scripts.Players.Handlers;
using Zenject;

namespace Game.Scripts.Players.Main
{
    public class PlayerCharacterInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<PlayerInputState>().AsSingle(); 
            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            //Container.Bind<IPlayerMover>().AsSingle().WithArguments(this.GetComponent<IPlayerMover>());
            Container.BindInterfacesTo<PlayerMoveHandler>().AsSingle().WithArguments(GetComponent<IPlayerMover>());
                     
            Container.BindExecutionOrder<PlayerInputHandler>(-10000);
        }
    }
}
