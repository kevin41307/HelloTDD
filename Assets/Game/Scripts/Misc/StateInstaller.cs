
using Zenject;
using UnityEngine;
using Game.Scripts.Players.Main;

namespace Game.Scripts.Misc
{
    public class StateInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GamePauseState>().AsSingle();
            Container.Bind<PlayerInputState>().AsSingle();
            Container.Bind<UserPressPauseAction>().AsSingle();
        }
    }
}