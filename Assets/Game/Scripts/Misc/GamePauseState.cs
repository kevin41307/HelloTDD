
using UnityEngine;
using Zenject;

namespace Game.Scripts.Misc
{
    public class GamePauseState : BaseState
    {
        [Inject] UserPressPauseAction userPressPauseAction;


        public override void Setup()
        {
            actions.Add(userPressPauseAction);
        }
    }
}