
using UnityEngine;
using Zenject;

namespace Game.Scripts.Misc
{
    [CreateAssetMenu(fileName = "GamePauseState", menuName = "Pluggable/GamePauseState")]
    public class GamePauseState : BaseState
    {
        public override void InstallBindings()
        {
            
        }
    }
}