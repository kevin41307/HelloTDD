using UnityEngine;
using Zenject;

namespace Game.Scripts.Players.Datas
{
    [CreateAssetMenu(fileName = "PlayerCharacterData", menuName = "PlayerCharacterData", order = 0)]
    public class PlayerCharacterData : ScriptableObjectInstaller
    {
        [SerializeField]
        private float moveSpeed;

        public override void InstallBindings()
        {
            Container.Bind<float>().WithId("MoveSpeed").FromInstance(moveSpeed);
        }

    }
}