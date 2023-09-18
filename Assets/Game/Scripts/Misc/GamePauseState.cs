using UnityEngine;
using Zenject;

namespace Game.Scripts.Misc
{
    public class GamePauseState : BaseState, IInitializable
    {
        [Inject] UserPressPauseAction userPressPauseAction;

        public void Initialize()
        {
            Setup();
        }

        public override void Setup()
        {
            actions.Add(userPressPauseAction);
        }
    }
}