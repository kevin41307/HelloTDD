
using Game.Scripts.Players.Main;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Players.Handlers
{
    public class PlayerInputHandler : ITickable
    {
        [Inject] PlayerInputState inputState;
        public void Tick()
        {
            inputState.SetHorizontal(Input.GetAxisRaw("Horizontal"));
            inputState.SetVertical(Input.GetAxisRaw("Vertical"));
        }
    }
}
