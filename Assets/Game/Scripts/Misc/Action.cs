
using UnityEngine;

namespace Game.Scripts.Misc
{
    public abstract class Action : ScriptableObject
    {
        public abstract bool Act(IStateController stateController);  
    }
}