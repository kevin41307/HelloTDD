using Game.Scripts.Battle.Misc;
using Game.Scripts.Players.Main;
using UnityEngine;
using Zenject;
using Game.Scripts.Misc;
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

        [Inject] GamePauseState GamePauseState { get; set; }


        public Vector2 CalMovement()
        {
            var x = deltaTimeProvider.GetDeltaTime();
            var y = mover.MoveSpeed;
            return x * y * inputState.MoveDirection ; 
        }

        public void Tick()
        {
            if(GamePauseState.Evaluate()) return;
            var movement = CalMovement();
            var newPos = mover.GetPos() + movement;
            mover.SetPos( newPos );
        }
    }
}
