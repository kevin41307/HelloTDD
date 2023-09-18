
using Game.Scripts.Players.Main;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Misc
{
    public class UserPressPauseAction : IAction
    {
        [Inject] PlayerInputState inputState;

        public bool Act()
        {
            return inputState.isPressPauseBtn;
        }

    }
}