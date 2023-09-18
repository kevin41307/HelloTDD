
using Game.Scripts.Players.Main;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Misc.Datas
{
    [CreateAssetMenu(menuName = "UserPressPauseActionData", fileName = "UserPressPauseActionData")]
    public class UserPressPauseActionData : ScriptableObjectInstaller
    {   

        public override void InstallBindings()
        {
            Container.Bind<PlayerInputState>().AsSingle();
            Container.Bind<UserPressPauseAction>().AsSingle();
            //Debug.Log(action.Act());
        }
    }
}