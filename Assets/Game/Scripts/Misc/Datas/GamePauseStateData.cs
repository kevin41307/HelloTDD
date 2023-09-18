
using Game.Scripts.Players.Main;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Misc.Datas
{

    [CreateAssetMenu(fileName = "GamePauseStateData", menuName = "GamePauseStateData", order = 0)]
    public class GamePauseStateData : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GamePauseState>().AsSingle();
        }

    }        
    
}