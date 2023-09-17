
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Misc
{
    [CreateAssetMenu(fileName = "New BaseState", menuName = "Pluggable/State")]
    public class BaseState : ScriptableObjectInstaller, IBaseState
    {
        public List<Action> actions = new List<Action>();

        protected bool And(IStateController controller, bool defaultValue = false)
        {
            if(actions.Count <= 0 ) 
            {
                Debug.Log("BaseState actions is empty, return defaultValue"+ defaultValue);
                return defaultValue;    
            }
            foreach (var action in actions) 
            {
                bool res = action.Act(controller);
                if(!res)
                    return false;
            }
            return true;
        }

        public bool Evaluate()
        {
            return Or(null);
        }

        protected bool Or(IStateController controller, bool defaultValue = false)
        {
            if(actions.Count <= 0 ) 
            {
                Debug.Log("BaseState actions is empty, return defaultValue" + defaultValue);
                return defaultValue;    
            }
            foreach (var action in actions) 
            {
                bool res = action.Act(controller);
                if(res)
                    return true;
            }
            return false;
        }
    }
}