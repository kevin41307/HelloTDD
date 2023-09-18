
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Misc
{
    public abstract class BaseState : IStateEvaluator
    {
        public List<IAction> actions = new List<IAction>();

        public abstract void Setup();

        public bool Evaluate()
        {
            return Or();
        }
        protected bool Or(bool defaultValue = false)
        {
            if(actions.Count <= 0 ) 
            {
                Debug.Log("BaseState actions is empty, return defaultValue" + defaultValue);
                return defaultValue;    
            }
            foreach (var action in actions) 
            {
                bool res = action.Act();
                if(res)
                    return true;
            }
            return false;
        }

/*
        protected bool And(IStateController controller, bool defaultValue = false)
        {
            if(actions.Count <= 0 ) 
            {
                Debug.Log("BaseState actions is empty, return defaultValue"+ defaultValue);
                return defaultValue;    
            }
            foreach (var action in actions) 
            {
                bool res = action.Act();
                if(!res)
                    return false;
            }
            return true;
        }
*/
    }
}