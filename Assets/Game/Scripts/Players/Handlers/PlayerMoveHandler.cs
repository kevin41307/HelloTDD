using Game.Scripts.Battle.Misc;
using Game.Scripts.Players.Main;
using NSubstitute;
using UnityEngine;
using Zenject;
namespace Game.Scripts.Players.Handlers
{
    public class PlayerMoveHandler : ITickable
    {
        private readonly IPlayerMover mover;
        public PlayerMoveHandler(IPlayerMover mover)
        {
            this.mover = mover;
        }

        [Inject] PlayerInputState inputState;

        [Inject] IDeltaTimeProvider deltaTimeProvider;

        public Vector2 CalMovement()
        {
            var x = deltaTimeProvider.GetDeltaTime();
            var y = mover.MoveSpeed;
            return x * y * inputState.MoveDirection; 
        }

        public void Tick()
        {
            if(inputState.isLocked) return;
            var movement = CalMovement();
            var newPos = mover.GetPos() + movement;
            mover.SetPos( newPos );
        }
    }
}
