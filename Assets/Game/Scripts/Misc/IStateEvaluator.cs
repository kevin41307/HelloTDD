using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Misc
{
    public interface IStateEvaluator
    {
        public bool Evaluate(List<IAction> actions);
    }

    public class StateEvaluator : IStateEvaluator
    {
        public bool Evaluate(List<IAction> actions)
        {
            if(actions.Count <= 0 ) 
            {
                Debug.Log("BaseState actions is empty, return defaultValue" + false);
                return false;    
            }
            foreach (var action in actions) 
            {
                bool res = action.Act();
                if(res)
                    return true;
            }
            return false;
        }
    }
}