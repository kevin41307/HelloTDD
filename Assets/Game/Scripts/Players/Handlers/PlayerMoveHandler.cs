using Game.Scripts.Battle.Misc;
using Game.Scripts.Players.Main;
using NSubstitute;
using UnityEngine;
using Zenject;
using Game.Scripts.Misc;
namespace Game.Scripts.Players.Handlers
{
    public class PlayerMoveHandler : ITickable, IStateController
    {
        private readonly IPlayerMover mover;
        public PlayerMoveHandler(IPlayerMover mover)
        {
            this.mover = mover;
        }

        [Inject] PlayerInputState inputState;

        [Inject] IDeltaTimeProvider deltaTimeProvider;

        [Inject(Id = "GamePauseState")] IBaseState gamePauseState;


        public Vector2 CalMovement()
        {
            var x = deltaTimeProvider.GetDeltaTime();
            var y = mover.MoveSpeed;
            return x * y * inputState.MoveDirection ; 
        }

        public void Tick()
        {
            if(gamePauseState.Evaluate()) return;
            var movement = CalMovement();
            var newPos = mover.GetPos() + movement;
            mover.SetPos( newPos );
        }
    }
}
