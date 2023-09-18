using Game.Scripts.Misc;
using Game.Scripts.Players.Handlers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Players.Main
{
    public class PlayerCharacterInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerMoveHandler>().AsSingle().WithArguments(GetComponent<IPlayerMover>());
            Container.BindExecutionOrder<PlayerInputHandler>(-10000);
        }
    }
}
