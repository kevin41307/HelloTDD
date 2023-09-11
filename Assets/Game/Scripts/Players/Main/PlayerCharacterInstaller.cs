﻿using Game.Scripts.Players.Handlers;
using Zenject;

namespace Game.Scripts.Players.Main
{
    public class PlayerCharacterInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<PlayerInputState>().AsSingle(); 
            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerMoveHandler>().AsSingle();
                     
            Container.BindExecutionOrder<PlayerInputHandler>(-10000);
        }
    }
}