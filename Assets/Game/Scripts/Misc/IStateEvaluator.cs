using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Misc
{
    public interface IStateEvaluator
    {
        public bool Evaluate();
    }
    
}