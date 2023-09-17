
using Game.Scripts.Players.Main;
using UnityEngine;

namespace Game.Scripts.Misc
{
    [CreateAssetMenu(fileName = "New Action", menuName = "Pluggable/Action")]
    public class UserPressPauseAction : Action
    {
        PlayerInputState inputState;
        public override bool Act(IStateController stateController)
        {
            return inputState.isPressPauseBtn;
        }
    }
}