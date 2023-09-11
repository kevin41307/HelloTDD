using Game.Scripts.Players.Main;
using NSubstitute;
using UnityEngine;
using Zenject;
namespace Game.Scripts.Players.Handlers
{
    public class PlayerMoveHandler : ITickable
    {
        public Player character;

        [Inject] public PlayerInputState inputState;

        [Inject] public IDeltaTimeProvider deltaTimeProvider;

        public Vector2 CalMovement()
        {
            return deltaTimeProvider.GetDeltaTime() * character.MoveSpeed * inputState.MoveDirection; 
        }

        public void Tick()
        {
            var movement = CalMovement();
            Debug.Log("movement" + movement);
            Debug.Log("playerCharacter.GetPosAA" + character.Trans);
            Debug.Log("playerCharacter.GetPosAA" + character.GetPos());
            character.SetPos(character.GetPos() + movement );
            Debug.Log("playerCharacter.GetPosBB" + character.GetPos());
            Debug.Log("playerCharacter.GetPosBB" + character.Trans);
        }
    }
}
